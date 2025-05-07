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

    public class BedTypeDTO
    {
        public int BedTypeID { get; set; }
        public string BedTypeName { get; set; }
        public string Description { get; set; }

        public BedTypeDTO(int bedTypeID, string bedTypeName, string description)
        {
            BedTypeID = bedTypeID;
            BedTypeName = bedTypeName;
            Description = description;
        }
    }

    public class clsBedTypeData
    {
        public static int AddNewBedType(BedTypeDTO bedTypeDTO)
        {
            int BedTypeID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@BedTypeName", bedTypeDTO.BedTypeName);
                        if (bedTypeDTO.Description != null && bedTypeDTO.Description != "")
                            Command.Parameters.AddWithValue("@Description", bedTypeDTO.Description);
                        else
                            Command.Parameters.AddWithValue("@Description", DBNull.Value);


                        SqlParameter outputIdParam = new SqlParameter("@NewBedTypeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        BedTypeID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                BedTypeID = -1;
            }
            return BedTypeID;
        }

        public static bool UpdateBedType(BedTypeDTO bedTypeDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BedTypeID", bedTypeDTO.BedTypeID);
                        Command.Parameters.AddWithValue("@BedTypeName", bedTypeDTO.BedTypeName);
                        if (bedTypeDTO.Description != null && bedTypeDTO.Description != "")
                            Command.Parameters.AddWithValue("@Description", bedTypeDTO.Description);
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

        public static bool DeleteBedType(int BedTypeID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BedTypeID", BedTypeID);


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

        public static List<BedTypeDTO> GetAllBedTypes()
        {
            List<BedTypeDTO> bedTypesLists = new List<BedTypeDTO>(); 

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                bedTypesLists.Add(
                                    new BedTypeDTO(
                                        Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                        Reader.GetString(Reader.GetOrdinal("BedTypeName")),
                                        Reader.IsDBNull(Reader.GetOrdinal("Description"))?"": Reader.GetString(Reader.GetOrdinal("Description"))
                                        )
                                    ); 
                            }
                               
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);

            }

            return bedTypesLists;
        }

        public static BedTypeDTO GetBedTypeInfoByID( int BedTypeID)
        {
            BedTypeDTO bedType = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetBedTypeInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BedTypeID", BedTypeID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                bedType = new BedTypeDTO(
                                        Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                        Reader.GetString(Reader.GetOrdinal("BedTypeName")),
                                        Reader.IsDBNull(Reader.GetOrdinal("Description")) ? "" : Reader.GetString(Reader.GetOrdinal("Description"))
                                        );

                            }
                            else
                                bedType = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                bedType = null;
            }
            return bedType;

        }

        public static BedTypeDTO GetBedTypeInfoByName(string BedTypeName)
        {
            BedTypeDTO bedType = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetBedTypeInfoByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BedTypeName", BedTypeName);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                bedType = new BedTypeDTO(
                                        Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                        Reader.GetString(Reader.GetOrdinal("BedTypeName")),
                                        Reader.IsDBNull(Reader.GetOrdinal("Description")) ? "" : Reader.GetString(Reader.GetOrdinal("Description"))
                                        );

                            }
                            else
                                bedType = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                bedType = null;
            }
            return bedType;

        }

        public static bool IsBedTypeExist(string BedTypeName)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsBedTypeExistByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@BedTypeName", BedTypeName);
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
