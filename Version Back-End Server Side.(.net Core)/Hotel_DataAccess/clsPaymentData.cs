using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Hotel_DataAccess
{

    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public byte PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public PaymentDTO(int paymentID, float paymentAmount, DateTime paymentDate, 
            byte paymentMethod, string notes, int createdByEmployeeID)
        {
            PaymentID = paymentID;
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            Notes = notes;
            CreatedByEmployeeID = createdByEmployeeID;
        }
    }

    public class PaymentsListDTO
    {
        public int PaymentID { get; set; }
        public int BookingID {  get; set; }
        public string NationalNo {  get; set; }
        public string FullName { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public PaymentsListDTO(int paymentID, int bookingID, string nationalNo, 
            string fullName, float paymentAmount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            BookingID = bookingID;
            NationalNo = nationalNo;
            FullName = fullName;
            PaymentAmount = paymentAmount;
            PaymentDate = paymentDate;
        }
    }
    public class clsPaymentData
    {
        public static int AddNewPayment(PaymentDTO paymentDTO)
        {
            int PaymentID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewPayment", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@PaymentAmount", paymentDTO.PaymentAmount);
                        Command.Parameters.AddWithValue("@PaymentDate", paymentDTO.PaymentDate);
                        Command.Parameters.AddWithValue("@PaymentMethod", paymentDTO.PaymentMethod);
                        if (paymentDTO.Notes != null && paymentDTO.Notes != "")
                            Command.Parameters.AddWithValue("@Notes", paymentDTO.Notes);
                        else
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", paymentDTO.CreatedByEmployeeID);


                        SqlParameter outputIdParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        PaymentID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                PaymentID = -1;
            }
            return PaymentID;
        }

        public static bool UpdatePayment(PaymentDTO paymentDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdatePayment", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PaymentID", paymentDTO.PaymentID);
                        Command.Parameters.AddWithValue("@PaymentAmount", paymentDTO.PaymentAmount);
                        Command.Parameters.AddWithValue("@PaymentDate", paymentDTO.PaymentDate);
                        Command.Parameters.AddWithValue("@PaymentMethod", paymentDTO.PaymentMethod);
                        if (paymentDTO.Notes != null&& paymentDTO.Notes != "")
                            Command.Parameters.AddWithValue("@Notes", paymentDTO.Notes);
                        else
                            Command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", paymentDTO.CreatedByEmployeeID);



                        RowsEffected = Command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RowsEffected = 0;
            }

            return RowsEffected > 0;
        }

        public static bool DeletePayment(int PaymentID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeletePayment", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PaymentID", PaymentID);


                        RowsEffected = Command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RowsEffected = 0;
            }

            return RowsEffected > 0;
        }

        public static List<PaymentsListDTO> GetAllPayments()
        {
            List<PaymentsListDTO> paymentsLists=new List<PaymentsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllPayments", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                paymentsLists.Add(new PaymentsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("PaymentID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("PaymentAmount")),
                                    Reader.GetDateTime(Reader.GetOrdinal("PaymentDate"))
                                    

                                    ));
                            }
                                
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);

            }

            return paymentsLists;
        }

        public static bool IsPaymentExist(int PaymentID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsPaymentExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        SqlParameter IsFoundParam = new SqlParameter("@IsFound", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(IsFoundParam);

                        Command.ExecuteNonQuery();
                        IsFound = ((int)IsFoundParam.Value == 1);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                IsFound = false;
            }
            return IsFound;
        }

        public static PaymentDTO  GetPaymentInfoByID( int PaymentID)
        {
            PaymentDTO paymentDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetPaymentInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                paymentDTO = new PaymentDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("PaymentID")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("PaymentAmount")),
                                    Reader.GetDateTime(Reader.GetOrdinal("PaymentDate")),
                                    Reader.GetByte(Reader.GetOrdinal("PaymentMethod")),
                                    Reader.IsDBNull(Reader.GetOrdinal("Notes")) ?"":Reader.GetString(Reader.GetOrdinal("Notes")),
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByEmployeeID"))
                                    
                                    );
                            }
                            else
                                paymentDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                paymentDTO = null;
            }
            return paymentDTO;

        }

        public static List<PaymentsListDTO> GetAllPaymentsForPageNumber(int PageNumber)
        {
            List<PaymentsListDTO> paymentsLists = new List<PaymentsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllPaymentsForPageNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                paymentsLists.Add(new PaymentsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("PaymentID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("PaymentAmount")),
                                    Reader.GetDateTime(Reader.GetOrdinal("PaymentDate"))


                                    ));
                            }
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);

            }

            return paymentsLists;
        }
    }
}
