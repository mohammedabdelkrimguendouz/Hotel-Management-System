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
    public class RoomClassFeatureDTO
    {
        public int RoomClassFeatureID { get; set; }
        public int RoomClassID { get; set; }
        public int FeatureID { get; set; }

        public RoomClassFeatureDTO(int roomClassFeatureID, int roomClassID, int featureID)
        {
            RoomClassFeatureID = roomClassFeatureID;
            RoomClassID = roomClassID;
            FeatureID = featureID;
        }
    }

    public class RoomClassFeaturesListDTO
    {
        public int RoomClassFeatureID { get; set; }
        public int RoomClassID { get; set; }
        public string RoomClassName { get; set; }

        public float BasePrice {  get; set; }
        public int FeatureID { get; set; }

        public string FeatureName { get; set; }

        public RoomClassFeaturesListDTO(int roomClassFeatureID, int roomClassID, string roomClassName,
            float basePrice, int featureID, string featureName)
        {
            RoomClassFeatureID = roomClassFeatureID;
            RoomClassID = roomClassID;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
            FeatureID = featureID;
            FeatureName = featureName;
        }
    }

    public class FeaturesForRoomClassListDTO
    {
        public int RoomClassFeatureID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }

        public FeaturesForRoomClassListDTO(int roomClassFeatureID, int featureID, string featureName)
        {
            RoomClassFeatureID = roomClassFeatureID;
            FeatureID = featureID;
            FeatureName = featureName;
        }
    }


    public class clsRoomClassFeatureData
    {
        public static int AddNewRoomClassFeature(RoomClassFeatureDTO roomClassFeatureDTO)
        {
            int RoomClassFeatureID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewRoomClassFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@RoomClassID", roomClassFeatureDTO.RoomClassID);
                        Command.Parameters.AddWithValue("@FeatureID", roomClassFeatureDTO.FeatureID);


                        SqlParameter outputIdParam = new SqlParameter("@NewRoomClassFeatureID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        RoomClassFeatureID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RoomClassFeatureID = -1;
            }
            return RoomClassFeatureID;
        }

        public static bool UpdateRoomClassFeature(RoomClassFeatureDTO roomClassFeatureDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateRoomClassFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassFeatureID", roomClassFeatureDTO.RoomClassFeatureID);
                        Command.Parameters.AddWithValue("@RoomClassID", roomClassFeatureDTO.RoomClassID);
                        Command.Parameters.AddWithValue("@FeatureID", roomClassFeatureDTO.FeatureID);



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

        public static bool DeleteRoomClassFeature(int RoomClassFeatureID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteRoomClassFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassFeatureID", RoomClassFeatureID);


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

        public static List<RoomClassFeaturesListDTO> GetAllRoomClassFeatures()
        {
            List<RoomClassFeaturesListDTO> roomClassFeaturesLists = new List<RoomClassFeaturesListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomClassFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                roomClassFeaturesLists.Add(new RoomClassFeaturesListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassFeatureID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID")),
                                    Reader.GetString(Reader.GetOrdinal("FeatureName"))
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

            return roomClassFeaturesLists;
        }

        public static RoomClassFeatureDTO GetRoomClassFeatureInfoByID(int RoomClassFeatureID)
        {
            RoomClassFeatureDTO roomClassFeatureDTO;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomClassFeatureInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassFeatureID", RoomClassFeatureID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                roomClassFeatureDTO = new RoomClassFeatureDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassFeatureID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID"))
                                    );

                            }
                            else
                                roomClassFeatureDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomClassFeatureDTO = null;
            }
            return roomClassFeatureDTO;

        }
        public static List<FeaturesForRoomClassListDTO> GetAllFeaturesForRoomClass(int RoomClassID)
        {
            List<FeaturesForRoomClassListDTO> featuresForRoomClassLists= new List<FeaturesForRoomClassListDTO> ();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllFeaturesForRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                featuresForRoomClassLists.Add(new FeaturesForRoomClassListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassFeatureID")),
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID")),
                                    Reader.GetString(Reader.GetOrdinal("FeatureName"))
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

            return featuresForRoomClassLists;
        }

        public static bool IsRoomClassFeatureExistByFeatureAndRoomClass(int FeatureID, int RoomClassID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomClassFeatureExistByFeatureAndRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        Command.Parameters.AddWithValue("@FeatureID", FeatureID);
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
    }
}
