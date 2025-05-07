
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DVLD_DataAccess;

namespace Hotel_DataAccess
{
    public class RoomClassDTO
    {
        public int RoomClassID { get; set; }
        public string RoomClassName { get; set; }
        public float BasePrice { get; set; }

        public RoomClassDTO(int roomClassID, string roomClassName, float basePrice)
        {
            RoomClassID = roomClassID;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
        }
    }

    public class RoomClassesListDTO
    {
        public int RoomClassID { get; set; }
        public string RoomClassName { get; set; }
        public float BasePrice { get; set; }

        public int NumberOfBedTypes {  get; set; }

        public int NumberOfFeatures {  get; set; }

        public RoomClassesListDTO(int roomClassID, string roomClassName, float basePrice, int numberOfBedTypes, int numberOfFeatures)
        {
            RoomClassID = roomClassID;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
            NumberOfBedTypes = numberOfBedTypes;
            NumberOfFeatures = numberOfFeatures;
        }
    }

    public class clsRoomClassData
    {
        public static int AddNewRoomClass(RoomClassDTO roomClassDTO)
        {
            int RoomClassID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@RoomClassName", roomClassDTO.RoomClassName);
                        Command.Parameters.AddWithValue("@BasePrice", roomClassDTO.BasePrice);


                        SqlParameter outputIdParam = new SqlParameter("@NewRoomClassID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        RoomClassID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RoomClassID = -1;
            }
            return RoomClassID;
        }

        public static bool UpdateRoomClass(RoomClassDTO roomClassDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", roomClassDTO.RoomClassID);
                        Command.Parameters.AddWithValue("@RoomClassName", roomClassDTO.RoomClassName);
                        Command.Parameters.AddWithValue("@BasePrice", roomClassDTO.BasePrice);



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

        public static bool DeleteRoomClass(int RoomClassID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);


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

        public static RoomClassDTO GetRoomClassInfoByID(int RoomClassID)
        {
            RoomClassDTO roomClassDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomClassInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomClassDTO = new RoomClassDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice"))
                                    );


                            }
                            else
                                roomClassDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomClassDTO = null;
            }
            return roomClassDTO;

        }

        public static RoomClassDTO GetRoomClassInfoByName(string RoomClassName)
        {
            RoomClassDTO roomClassDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomClassInfoByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassName", RoomClassName);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomClassDTO = new RoomClassDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice"))
                                    );


                            }
                            else
                                roomClassDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomClassDTO = null;
            }
            return roomClassDTO;

        }

        public static bool IsRoomClassExistByID(int RoomClassID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomClassExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
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

        public static bool IsRoomClassExistByName(string RoomClassName)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomClassExistByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassName", RoomClassName);
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

        public static int GetNumberOfBedTypes(int RoomClassID)
        {
            int NumberOfBedTypes = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetNumberOfBedTypes", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        SqlParameter NumberParam = new SqlParameter("@NumberOfBedTypes", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(NumberParam);

                        Command.ExecuteNonQuery();

                        NumberOfBedTypes = ((int)NumberParam.Value);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                NumberOfBedTypes = 0;
            }
            return NumberOfBedTypes;
        }

        public static int GetNumberOfFeatures(int RoomClassID)
        { 
            int NumberOfFeatures = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetNumberOfFeatures", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        SqlParameter NumberParam = new SqlParameter("@NumberOfFeatures", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        Command.Parameters.Add(NumberParam);

                        Command.ExecuteNonQuery();

                        NumberOfFeatures = ((int)NumberParam.Value);

                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                NumberOfFeatures = 0;
            }
            return NumberOfFeatures;
        }
        public static List<RoomClassesListDTO> GetAllRoomClasses()
        {
            List<RoomClassesListDTO> roomClassesList = new List<RoomClassesListDTO>(); 
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomClasse", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                roomClassesList.Add(new RoomClassesListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfBedTypes")),
                                    Reader.GetInt32(Reader.GetOrdinal("NumberOfFeatures"))
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

            return roomClassesList;
        }
    }
}
