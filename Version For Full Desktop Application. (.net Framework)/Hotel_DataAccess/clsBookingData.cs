using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccess
{
    public class clsBookingData
    {
        public static int AddNewBooking(int GuestID, int PaymentID, short BookingStatus, DateTime CheckInDate,
            DateTime CheckOutDate, short NumberAdults, short NumberChildren, float BookingAmount, float Discount, int CreatedByEmployeeID)
        {
            int BookingID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewBooking", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@GuestID", GuestID);
                        Command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        Command.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                        Command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
                        Command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
                        Command.Parameters.AddWithValue("@NumberAdults", NumberAdults);
                        Command.Parameters.AddWithValue("@NumberChildren", NumberChildren);
                        Command.Parameters.AddWithValue("@BookingAmount", BookingAmount);
                        Command.Parameters.AddWithValue("@Discount", Discount);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", CreatedByEmployeeID);


                        SqlParameter outputIdParam = new SqlParameter("@NewBookingID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        BookingID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                BookingID = -1;
            }
            return BookingID;
        }

        public static bool UpdateBooking(int BookingID, int GuestID, int PaymentID, short BookingStatus, DateTime CheckInDate, DateTime CheckOutDate, short NumberAdults, short NumberChildren, float BookingAmount, float Discount, int CreatedByEmployeeID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateBooking", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);
                        Command.Parameters.AddWithValue("@GuestID", GuestID);
                        Command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        Command.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                        Command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
                        Command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
                        Command.Parameters.AddWithValue("@NumberAdults", NumberAdults);
                        Command.Parameters.AddWithValue("@NumberChildren", NumberChildren);
                        Command.Parameters.AddWithValue("@BookingAmount", BookingAmount);
                        Command.Parameters.AddWithValue("@Discount", Discount);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", CreatedByEmployeeID);



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

        public static bool DeleteBooking(int BookingID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteBooking", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);


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

        public static DataTable GetAllBookings()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllBookings", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                dt.Load(Reader);
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);

            }

            return dt;
        }

        public static DataTable GetAllBookingsForPageNumber(int PageNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllBookingsForPageNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                dt.Load(Reader);
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);

            }

            return dt;
        }

        public static bool IsBookingExist(int BookingID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsBookingExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);
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

        public static bool DeosExistBookingActiveForGuest(int GuestID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeosExistBookingActiveForGuest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@GuestID", GuestID);
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

        public static bool GetBookingInfoByID( int BookingID, ref int GuestID, ref int PaymentID, ref short BookingStatus, ref DateTime CheckInDate, ref DateTime CheckOutDate, ref short NumberAdults, ref short NumberChildren, ref float BookingAmount, ref float Discount, ref int CreatedByEmployeeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetBookingInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                GuestID = (int)Reader["GuestID"];
                                PaymentID = (int)Reader["PaymentID"];
                                BookingStatus = (byte)Reader["BookingStatus"];
                                CheckInDate = (DateTime)Reader["CheckInDate"];
                                CheckOutDate = (DateTime)Reader["CheckOutDate"];
                                NumberAdults = (byte)Reader["NumberAdults"];
                                NumberChildren = (byte)Reader["NumberChildren"];
                                BookingAmount = Convert.ToSingle(Reader["BookingAmount"]);
                                Discount = Convert.ToSingle(Reader["Discount"]);
                                CreatedByEmployeeID = (int)Reader["CreatedByEmployeeID"];


                            }
                            else
                                IsFound = false;
                        }
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


        public static bool SetCancelBooking(int BookingID)
        {
            bool Success = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_SetCancelBooking", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);
                        SqlParameter SuccessParam = new SqlParameter("@Success", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(SuccessParam);

                        Command.ExecuteNonQuery();
                        Success = ((int)SuccessParam.Value == 1);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                Success = false;
            }
            return Success;
        }

        public static bool UpdateBookingStatusIfCompleted()
        {
            bool Success = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateBookingStatusIfCompleted", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                       
                        SqlParameter SuccessParam = new SqlParameter("@Success", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(SuccessParam);

                        Command.ExecuteNonQuery();
                        Success = ((int)SuccessParam.Value == 1);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                Success = false;
            }
            return Success;
        }
    }
}
