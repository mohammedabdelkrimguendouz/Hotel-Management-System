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
    public class GuestDTO
    {
        public int GuestID { get; set; }
        public int PersonID { get; set; }
        public short LoyaltyPoints { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public GuestDTO(int guestID, int personID, short loyaltyPoints, int createdByEmployeeID)
        {
            GuestID = guestID;
            PersonID = personID;
            LoyaltyPoints = loyaltyPoints;
            CreatedByEmployeeID = createdByEmployeeID;
        }
    }
    public class GuestsListDTO
    {
        public int GuestID { get; set; }
        public int PersonID { get; set; }
        public string NationalNo {  get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public int NumberOfBookings { get; set; }

        public GuestsListDTO(int guestID, int personID, string nationalNo, string fullName,
            string phone, int numberOfBookings)
        {
            GuestID = guestID;
            PersonID = personID;
            NationalNo = nationalNo;
            FullName = fullName;
            Phone = phone;
            NumberOfBookings = numberOfBookings;
        }
    }

    public class clsGuestData
    {
        public static int AddNewGuest(GuestDTO guestDTO)
        {
            int GuestID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewGuest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PersonID", guestDTO.PersonID);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", guestDTO.CreatedByEmployeeID);


                        SqlParameter outputIdParam = new SqlParameter("@NewGuestID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        GuestID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                GuestID = -1;
            }
            return GuestID;
        }

        public static bool UpdateGuest(GuestDTO guestDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateGuest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@GuestID", guestDTO.GuestID);
                        Command.Parameters.AddWithValue("@PersonID", guestDTO.PersonID);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", guestDTO.CreatedByEmployeeID);



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

        public static bool DeleteGuest(int GuestID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteGuest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@GuestID", GuestID);


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

        public static bool IsGuestExistByGuestID(int GuestID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsGuestExistByID", Connection))
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
        public static bool IsGuestExistForNationalNo(string NationalNo)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsGuestExistByNationalNo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
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

        public static GuestDTO GetGuestInfoByID(int GuestID)
        {
            GuestDTO guestDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetGuestInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@GuestID", GuestID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                guestDTO = new GuestDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("GuestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetByte(Reader.GetOrdinal("LoyaltyPoints")),
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByEmployeeID"))
                                    );


                            }
                            else
                                guestDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                guestDTO = null;
            }
            return guestDTO;

        }

        public static GuestDTO GetGuestInfoByNationalNo(string NationalNo)
        {
            GuestDTO guestDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetGuestInfoByNationalNo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                guestDTO = new GuestDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("GuestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetByte(Reader.GetOrdinal("LoyaltyPoints")),
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByEmployeeID"))
                                    );


                            }
                            else
                                guestDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                guestDTO = null;
            }
            return guestDTO;

        }

        public static List<GuestsListDTO> GetAllGuests()
        {
            List<GuestsListDTO> guestsLists = new List<GuestsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllGuest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                guestsLists.Add(new GuestsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("GuestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    Reader.GetString(Reader.GetOrdinal("Phone")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfBookings"))
                                    
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

            return guestsLists;
        }

        public static List<GuestsListDTO> GetAllGuestsForPageNumber(int PageNumber)
        {
            List<GuestsListDTO> guestsLists =new List<GuestsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllGuestsForPageNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                guestsLists.Add(new GuestsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("GuestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    Reader.GetString(Reader.GetOrdinal("Phone")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfBookings"))

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

            return guestsLists;
        }

        public static int GetNumberOfBookings(int GuestID)
        {
            int NumberOfBookings = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetNumberOfBookings", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@GuestID", GuestID);
                        SqlParameter NumberOfBookingsParam = new SqlParameter("@NumberOfBookings", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(NumberOfBookingsParam);

                        Command.ExecuteNonQuery();

                        NumberOfBookings = ((int)NumberOfBookingsParam.Value);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                NumberOfBookings = 0;
            }
            return NumberOfBookings;
        }

    }
}
