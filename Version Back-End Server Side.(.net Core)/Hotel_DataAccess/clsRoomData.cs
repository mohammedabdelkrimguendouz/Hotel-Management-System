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
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int FloorID { get; set; }
        public int RoomClassID { get; set; }
        public int RoomNumber { get; set; }
        public bool Available { get; set; }

        public RoomDTO(int roomID, int floorID, int roomClassID, int roomNumber, bool available)
        {
            RoomID = roomID;
            FloorID = floorID;
            RoomClassID = roomClassID;
            RoomNumber = roomNumber;
            Available = available;
        }
    }

    public class RoomsListDTO
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomClassName { get; set; }

        public float BasePrice {  get; set; }

        public byte FloorNumber { get; set; }



        public bool Available { get; set; }

        public RoomsListDTO(int roomID, int roomNumber, string roomClassName, float basePrice, byte floorNumber, bool available)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
            FloorNumber = floorNumber;
            Available = available;
        }
    }
    public class clsRoomData
    {
        public static int AddNewRoom(RoomDTO roomDTO)
        {
            int RoomID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
         
                        Command.Parameters.AddWithValue("@FloorID", roomDTO.FloorID);
                        Command.Parameters.AddWithValue("@RoomClassID", roomDTO.RoomClassID);
                        
                        Command.Parameters.AddWithValue("@RoomNumber", roomDTO.RoomNumber);
                        Command.Parameters.AddWithValue("@Available", roomDTO.Available);


                        SqlParameter outputIdParam = new SqlParameter("@NewRoomID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        RoomID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RoomID = -1;
            }
            return RoomID;
        }

        public static bool UpdateRoom(RoomDTO roomDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", roomDTO.RoomID);
                        Command.Parameters.AddWithValue("@FloorID", roomDTO.FloorID);
                        Command.Parameters.AddWithValue("@RoomClassID", roomDTO.RoomClassID);
         
                        Command.Parameters.AddWithValue("@RoomNumber", roomDTO.RoomNumber);
                        Command.Parameters.AddWithValue("@Available", roomDTO.Available);



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

        static public bool UpdateRoomStatus(int RoomID,bool NewStatus)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateRoomStatus", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        Command.Parameters.AddWithValue("@NewStatus", NewStatus);
                        
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
        public static bool DeleteRoom(int RoomID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);


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

        public static List<RoomsListDTO> GetAllRooms()
        {
            List<RoomsListDTO> roomsList = new List<RoomsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRooms", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                roomsList.Add(new RoomsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))
                                    
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

            return roomsList;
        }

        public static List<RoomsListDTO> GetAllRoomsForPageNumber(int PageNumber)
        {
            List<RoomsListDTO> roomsList = new List<RoomsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomsForPageNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                roomsList.Add(new RoomsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))

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

            return roomsList;
        }

        public static List<RoomsListDTO> GetAllRoomsForRoomClass(int RoomClassID)
        {
            List<RoomsListDTO> roomsList = new List<RoomsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomsForRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                roomsList.Add(new RoomsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))

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

            return roomsList;
        }

        

        public static List<RoomsListDTO> GetRoom(int RoomID)
        {
            List<RoomsListDTO> room=new List<RoomsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoom", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                room.Add(new RoomsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))

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

            return room;
        }


        public static bool IsRoomExist(int RoomID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
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

        public static bool IsRoomNumberExist(int RoomNumber)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomNumberExist", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
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

        public static RoomDTO GetRoomInfoByID( int RoomID)
        {
            RoomDTO roomDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomDTO = new RoomDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("FloorID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))
                                    );


                            }
                            else
                                roomDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomDTO = null;
            }
            return roomDTO;

        }

        public static RoomDTO GetRoomInfoByRoomNumber(int RoomNumber)
        {
            RoomDTO roomDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomInfoByRoomNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomDTO = new RoomDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("FloorID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetBoolean(Reader.GetOrdinal("Available"))
                                    );


                            }
                            else
                                roomDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomDTO = null;
            }
            return roomDTO;

        }

        public static int GetNumberOfMaintenanceRequests(int RoomID)
        {
            int NumberOfMaintenanceRequests = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetNumberOfMaintenanceRequests", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        SqlParameter NumberParam = new SqlParameter("@NumberOfMaintenanceRequests", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(NumberParam);

                        Command.ExecuteNonQuery();

                        NumberOfMaintenanceRequests = ((int)NumberParam.Value);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                NumberOfMaintenanceRequests = 0;
            }
            return NumberOfMaintenanceRequests;
        }
    }
}
