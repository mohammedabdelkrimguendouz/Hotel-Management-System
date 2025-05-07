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
    public class FeatureDTO
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string Description { get; set; }

        public FeatureDTO(int featureID, string featureName, string description)
        {
            FeatureID = featureID;
            FeatureName = featureName;
            Description = description;
        }
    }


    public class clsFeatureData
    {
        public static int AddNewFeature(FeatureDTO featureDTO)
        {
            int FeatureID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@FeatureName", featureDTO.FeatureName);
                        if (featureDTO.Description != null&& featureDTO.Description != "")
                            Command.Parameters.AddWithValue("@Description", featureDTO.Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);


                        SqlParameter outputIdParam = new SqlParameter("@NewFeatureID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        FeatureID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                FeatureID = -1;
            }
            return FeatureID;
        }

        public static bool UpdateFeature(FeatureDTO featureDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FeatureID", featureDTO);
                        Command.Parameters.AddWithValue("@FeatureName", featureDTO);
                        if (featureDTO.Description != null&& featureDTO.Description!="")
                            Command.Parameters.AddWithValue("@Description", featureDTO);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);



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

        public static bool DeleteFeature(int FeatureID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FeatureID", FeatureID);


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

        public static List<FeatureDTO> GetAllFeatures()
        {
            List<FeatureDTO> featuresList = new List<FeatureDTO> ();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllFeature", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                featuresList.Add(new FeatureDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID")),
                                    Reader.GetString(Reader.GetOrdinal("FeatureName")),
                                    Reader.IsDBNull(Reader.GetOrdinal("Description")) ? "" : Reader.GetString(Reader.GetOrdinal("Description"))
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

            return featuresList;
        }

        public static bool IsFeatureExistByID(int FeatureID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsFeatureExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
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

        public static bool IsFeatureExistByName(string FeatureName)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsFeatureExistByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FeatureName", FeatureName);
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

        public static FeatureDTO GetFeatureInfoByID( int FeatureID)
        {
            FeatureDTO featureDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetFeatureInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FeatureID", FeatureID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                featureDTO = new FeatureDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID")),
                                    Reader.GetString(Reader.GetOrdinal("FeatureName")),
                                    Reader.IsDBNull(Reader.GetOrdinal("Description"))?"": Reader.GetString(Reader.GetOrdinal("Description"))
                                    );



                            }
                            else
                                featureDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                featureDTO = null;
            }
            return featureDTO;

        }

        public static FeatureDTO GetFeatureInfoByName(string FeatureName)
        {
            FeatureDTO featureDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetFeatureInfoByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FeatureName", FeatureName);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                featureDTO = new FeatureDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FeatureID")),
                                    Reader.GetString(Reader.GetOrdinal("FeatureName")),
                                    Reader.IsDBNull(Reader.GetOrdinal("Description")) ? "" : Reader.GetString(Reader.GetOrdinal("Description"))
                                    );



                            }
                            else
                                featureDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                featureDTO = null;
            }
            return featureDTO;

        }
    }
}
