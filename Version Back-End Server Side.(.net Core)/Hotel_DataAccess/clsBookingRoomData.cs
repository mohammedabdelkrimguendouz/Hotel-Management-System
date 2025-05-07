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
    public class BookingRoomDTO
    {
        public int BookingRoomID { get; set; }
        public int BookingID { get; set; }
        
        public int RoomID { get; set; }

        public BookingRoomDTO(int bookingRoomID, int bookingID, int roomID)
        {
            BookingRoomID = bookingRoomID;
            BookingID = bookingID;
            RoomID = roomID;
        }
    }
    public class BookingRoomsListDTO
    {
        public int BookingRoomID { get; set; }
        public int BookingID { get; set; }

        public int RoomID { get; set; }
        public int RoomNumber {  get; set; }

        public BookingRoomsListDTO(int bookingRoomID, int bookingID, int roomID,int roomNumber)
        {
            BookingRoomID = bookingRoomID;
            BookingID = bookingID;
            RoomID = roomID;
            RoomNumber = roomNumber;
        }
    }

    public class RoomsForBookingsListDTO
    {
       
        
        public int RoomID { get; set; }
        public string RoomClassName {  get; set; }
        public float BasePrice { get; set; }
        public byte FloorNumber { get; set; }

        public int RoomNumber { get; set; }

        public RoomsForBookingsListDTO(int roomID, string roomClassName, float basePrice, byte floorNumber, int roomNumber)
        {
            RoomID = roomID;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
    }

    public class clsBookingRoomData
    {
        public static int AddNewBookingRoom(BookingRoomDTO bookingRoomDTO)
        {
            int BookingRoomID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewBookingRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
    
                        Command.Parameters.AddWithValue("@BookingID", bookingRoomDTO.BookingID);
                        Command.Parameters.AddWithValue("@RoomID", bookingRoomDTO.RoomID);


                        SqlParameter outputIdParam = new SqlParameter("@NewBookingRoomID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        BookingRoomID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                BookingRoomID = -1;
            }
            return BookingRoomID;
        }

        public static bool UpdateBookingRoom(BookingRoomDTO bookingRoomDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateBookingRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingRoomID", bookingRoomDTO.BookingRoomID);
                        Command.Parameters.AddWithValue("@BookingID", bookingRoomDTO.BookingID);
                        Command.Parameters.AddWithValue("@RoomID", bookingRoomDTO.RoomID);



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

        public static bool DeleteBookingRoom(int BookingRoomID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteBookingRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingRoomID", BookingRoomID);


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

        public static bool DeleteAllBookingRoomsForBookingID(int BookingID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteAllBookingRoomForBookingID", Connection))
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

        public static List<BookingRoomsListDTO> GetAllBookingRooms()
        {
            List<BookingRoomsListDTO> bookingRoomsLists= new List<BookingRoomsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllBookingRooms", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                bookingRoomsLists.Add(new BookingRoomsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("BookingRoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber"))
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

            return bookingRoomsLists;
        }

        public static List<RoomsForBookingsListDTO> GetAllRoomsForBookingID(int BookingID)
        {
            List<RoomsForBookingsListDTO> roomsForBookingsLists=new List<RoomsForBookingsListDTO> ();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomsForBookingID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingID", BookingID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomsForBookingsLists.Add(new RoomsForBookingsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber"))
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

            return roomsForBookingsLists;
        }

        public static bool IsBookingRoomExist(int BookingRoomID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsBookingRoomExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingRoomID", BookingRoomID);
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

        public static BookingRoomDTO GetBookingRoomInfoByID( int BookingRoomID)
        {
            BookingRoomDTO bookingRoomDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetBookingRoomInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BookingRoomID", BookingRoomID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                bookingRoomDTO = new BookingRoomDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("BookingRoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BookingID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID"))
                                    );


                            }
                            else
                                bookingRoomDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                bookingRoomDTO = null;
            }
            return bookingRoomDTO;

        }

    }
}
