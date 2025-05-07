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
    public class clsMaintenanceRequestData
    {
        public static int AddNewMaintenanceRequest(int RoomID, DateTime MaintenanceRequestDate, string Description, int CreatedByEmployeeID)
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
                       
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        Command.Parameters.AddWithValue("@MaintenanceRequestDate", MaintenanceRequestDate);
                       
                        
                        if (Description != null&&Description!="")
                            Command.Parameters.AddWithValue("@Description", Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);
                        Command.Parameters.AddWithValue("@CreatedByEmployeeID", CreatedByEmployeeID);


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

        public static bool UpdateMaintenanceRequest(int MaintenanceRequestID, int RoomID, DateTime MaintenanceRequestDate, string Description, int CreatedByEmployeeID)
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
                        Command.Parameters.AddWithValue("@MaintenanceRequestID", MaintenanceRequestID);
                        Command.Parameters.AddWithValue("@RoomID", RoomID);
                        Command.Parameters.AddWithValue("@MaintenanceRequestDate", MaintenanceRequestDate);
                        
                        if (Description != null && Description!="")
                            Command.Parameters.AddWithValue("@Description", Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);
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

        public static DataTable GetAllMaintenanceRequests()
        {
            DataTable dt = new DataTable();
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

        public static bool GetMaintenanceRequestInfoByID( int MaintenanceRequestID, ref int RoomID, ref DateTime MaintenanceRequestDate, ref bool IsCompleted, ref DateTime? CompletedDate, ref string Description, ref int CreatedByEmployeeID)
        {
            bool IsFound = false;
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
                                IsFound = true;
                                RoomID = (int)Reader["RoomID"];
                                MaintenanceRequestDate = (DateTime)Reader["MaintenanceRequestDate"];
                                IsCompleted = (bool)Reader["IsCompleted"];
                                CompletedDate = (Reader["CompletedDate"] == DBNull.Value) ? null  : (DateTime?)Reader["CompletedDate"];
                                Description = (Reader["Description"] == DBNull.Value) ? "": (string)Reader["Description"];
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

    }
}
