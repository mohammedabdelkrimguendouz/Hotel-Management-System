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
using Azure.Core.Pipeline;

namespace Hotel_DataAccess
{
    public class MaintenanceRequestDTO
    {
        public int MaintenanceRequestID { get; set; }
        public int RoomID { get; set; }
        public DateTime MaintenanceRequestDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Description { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public MaintenanceRequestDTO(int maintenanceRequestID, int roomID, DateTime maintenanceRequestDate,
            bool isCompleted, DateTime? completedDate, string description, int createdByEmployeeID)
        {
            MaintenanceRequestID = maintenanceRequestID;
            RoomID = roomID;
            MaintenanceRequestDate = maintenanceRequestDate;
            IsCompleted = isCompleted;
            CompletedDate = completedDate;
            Description = description;
            CreatedByEmployeeID = createdByEmployeeID;
        }
    }

    public class MaintenanceRequestsListDTO
    {
        public int MaintenanceRequestID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public DateTime MaintenanceRequestDate { get; set; }
        public bool IsCompleted { get; set; }
        public byte FloorNumber { get; set; }

        public MaintenanceRequestsListDTO(int maintenanceRequestID, int roomID, int roomNumber,
            DateTime maintenanceRequestDate, bool isCompleted, byte floorNumber)
        {
            MaintenanceRequestID = maintenanceRequestID;
            RoomID = roomID;
            RoomNumber = roomNumber;
            MaintenanceRequestDate = maintenanceRequestDate;
            IsCompleted = isCompleted;
            FloorNumber = floorNumber;
        }
    }
    public class clsMaintenanceRequestData
    {
        public static int AddNewMaintenanceRequest(MaintenanceRequestDTO maintenanceRequestDTO)
        {
            int MaintenanceRequestID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewMaintenanceRequest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                       
                        Command.Parameters.AddWithValue("@RoomID", maintenanceRequestDTO.RoomID);
                        Command.Parameters.AddWithValue("@MaintenanceRequestDate", maintenanceRequestDTO.MaintenanceRequestDate);
                       
                        
                        if (maintenanceRequestDTO.Description != null&& maintenanceRequestDTO.Description != "")
                            Command.Parameters.AddWithValue("@Description", maintenanceRequestDTO.Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", maintenanceRequestDTO.CreatedByEmployeeID);


                        SqlParameter outputIdParam = new SqlParameter("@NewMaintenanceRequestID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        MaintenanceRequestID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                MaintenanceRequestID = -1;
            }
            return MaintenanceRequestID;
        }

        public static bool UpdateMaintenanceRequest(MaintenanceRequestDTO maintenanceRequestDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateMaintenanceRequest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@MaintenanceRequestID", maintenanceRequestDTO.MaintenanceRequestID);
                        Command.Parameters.AddWithValue("@RoomID", maintenanceRequestDTO.RoomID);
                        Command.Parameters.AddWithValue("@MaintenanceRequestDate", maintenanceRequestDTO.MaintenanceRequestDate);
                        
                        if (maintenanceRequestDTO.Description != null && maintenanceRequestDTO.Description != "")
                            Command.Parameters.AddWithValue("@Description", maintenanceRequestDTO.Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", maintenanceRequestDTO.CreatedByEmployeeID);



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

        public static bool SetCompleteMaintenance(int RoomID)
        {
            bool Success = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_SetCompleteMaintenance", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
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

        public static bool DeleteMaintenanceRequest(int MaintenanceRequestID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteMaintenanceRequest", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@MaintenanceRequestID", MaintenanceRequestID);


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

        public static List<MaintenanceRequestsListDTO> GetAllMaintenanceRequests()
        {
            List<MaintenanceRequestsListDTO> maintenanceRequestsLists = new List<MaintenanceRequestsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllMaintenanceRequests", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                maintenanceRequestsLists.Add(new MaintenanceRequestsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("MaintenanceRequestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomNumber")),
                                    Reader.GetDateTime(Reader.GetOrdinal("MaintenanceRequestDate")),
                                    Reader.GetBoolean(Reader.GetOrdinal("IsCompleted")),
                                    
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber"))
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

            return maintenanceRequestsLists;
        }

        public static MaintenanceRequestDTO GetMaintenanceRequestInfoByID( int MaintenanceRequestID)
        {
            MaintenanceRequestDTO maintenanceRequestDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetMaintenanceRequestInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@MaintenanceRequestID", MaintenanceRequestID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                maintenanceRequestDTO = new MaintenanceRequestDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("MaintenanceRequestID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("MaintenanceRequestDate")),
                                    Reader.GetBoolean(Reader.GetOrdinal("IsCompleted")),
                                    Reader.IsDBNull(Reader.GetOrdinal("CompletedDate")) ?null:Reader.GetDateTime(Reader.GetString("CompletedDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("Description"))?"":Reader.GetString(Reader.GetOrdinal("Description")),
                                    Reader.GetInt32(Reader.GetOrdinal("CreatedByEmployeeID"))
                                    );


                            }
                            else
                                maintenanceRequestDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                maintenanceRequestDTO = null;
            }
            return maintenanceRequestDTO;

        }

    }
}
