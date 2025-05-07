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
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public int GuestID { get; set; }

       
        public int PaymentID { get; set; }
       
        public byte BookingStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public byte NumberAdults { get; set; }
        public byte NumberChildren { get; set; }
        public float BookingAmount { get; set; }
        public float Discount { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public BookingDTO(int bookingID, int guestID, int paymentID, byte bookingStatus, 
            DateTime checkInDate, DateTime checkOutDate, byte numberAdults, byte numberChildren,
            float bookingAmount, float discount, int createdByEmployeeID)
        {
            BookingID = bookingID;
            GuestID = guestID;
            PaymentID = paymentID;
            BookingStatus = bookingStatus;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberAdults = numberAdults;
            NumberChildren = numberChildren;
            BookingAmount = bookingAmount;
            Discount = discount;
            CreatedByEmployeeID = createdByEmployeeID;
        }
    }

    public class BookingsListDTO
    {
        public int BookingID { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }


       

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public float PaymentAmount { get; set; }

        public string BookingStatus { get; set; }
       
        public int NumberOfRooms { get; set; }

        public BookingsListDTO(int bookingID, string nationalNo, string fullName, DateTime checkInDate, 
            DateTime checkOutDate, float paymentAmount, string bookingStatus, int numberOfRooms)
        {
            BookingID = bookingID;
            NationalNo = nationalNo;
            FullName = fullName;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            PaymentAmount = paymentAmount;
            BookingStatus = bookingStatus;
            NumberOfRooms = numberOfRooms;
        }
    }
    public class clsBookingData
    {
        public static int AddNewBooking(BookingDTO bookingDTO)
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
                        
                        Command.Parameters.AddWithValue("@GuestID", bookingDTO.GuestID);
                        Command.Parameters.AddWithValue("@PaymentID", bookingDTO.PaymentID);
                        Command.Parameters.AddWithValue("@BookingStatus", bookingDTO.BookingStatus);
                        Command.Parameters.AddWithValue("@CheckInDate", bookingDTO.CheckInDate);
                        Command.Parameters.AddWithValue("@CheckOutDate", bookingDTO.CheckOutDate);
                        Command.Parameters.AddWithValue("@NumberAdults", bookingDTO.NumberAdults);
                        Command.Parameters.AddWithValue("@NumberChildren", bookingDTO.NumberChildren);
                        Command.Parameters.AddWithValue("@BookingAmount", bookingDTO.BookingAmount);
                        Command.Parameters.AddWithValue("@Discount", bookingDTO.Discount);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", bookingDTO.CreatedByEmployeeID);


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

        public static bool UpdateBooking(BookingDTO bookingDTO)
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
                        Command.Parameters.AddWithValue("@BookingID", bookingDTO.BookingID);
                        Command.Parameters.AddWithValue("@GuestID", bookingDTO.GuestID);
                        Command.Parameters.AddWithValue("@PaymentID", bookingDTO.PaymentID);
                        Command.Parameters.AddWithValue("@BookingStatus", bookingDTO.BookingStatus);
                        Command.Parameters.AddWithValue("@CheckInDate", bookingDTO.CheckInDate);
                        Command.Parameters.AddWithValue("@CheckOutDate", bookingDTO.CheckOutDate);
                        Command.Parameters.AddWithValue("@NumberAdults", bookingDTO.NumberAdults);
                        Command.Parameters.AddWithValue("@NumberChildren", bookingDTO.NumberChildren);
                        Command.Parameters.AddWithValue("@BookingAmount", bookingDTO.BookingAmount);
                        Command.Parameters.AddWithValue("@Discount", bookingDTO.Discount);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", bookingDTO.CreatedByEmployeeID);



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

        public static List<BookingsListDTO> GetAllBookings()
        {
           List<BookingsListDTO> bookingsLists = new List<BookingsListDTO>();
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
                            while(Reader.Read())
                            {
                                bookingsLists.Add(new BookingsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckInDate")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckOutDate")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("PaymentAmount")),
                                    Reader.GetString(Reader.GetOrdinal("BookingStatus")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfRooms"))

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

            return bookingsLists;
        }

        public static List<BookingsListDTO> GetAllBookingsForPageNumber(int PageNumber)
        {
            List<BookingsListDTO> bookingsLists=new List<BookingsListDTO>();
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
                            while (Reader.Read())
                            {
                                bookingsLists.Add(new BookingsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetString(Reader.GetOrdinal("NationalNo")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckInDate")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckOutDate")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("PaymentAmount")),
                                    Reader.GetString(Reader.GetOrdinal("BookingStatus")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfRooms"))

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

            return bookingsLists;
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

        public static BookingDTO GetBookingInfoByID( int BookingID)
        {
            BookingDTO bookingDTO = null;
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

                                bookingDTO = new BookingDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetInt32(Reader.GetOrdinal("GuestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PaymentID")),
                                    Reader.GetByte(Reader.GetOrdinal("BookingStatus")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckInDate")),
                                    Reader.GetDateTime(Reader.GetOrdinal("CheckOutDate")),
                                    Reader.GetByte(Reader.GetOrdinal("NumberAdults")),
                                    Reader.GetByte(Reader.GetOrdinal("NumberChildren")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BookingAmount")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("Discount")),
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByEmployeeID"))
                                    
                                    );

                            }
                            else
                                bookingDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                bookingDTO = null;
            }
            return bookingDTO;

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

        public static bool UpdateAllBookingStatusIfCompleted()
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
