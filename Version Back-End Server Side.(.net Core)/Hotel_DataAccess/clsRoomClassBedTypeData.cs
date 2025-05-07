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
    public class RoomClassBedTypeDTO
    {
        public int RoomClassBedTypeID { get; set; }
        public int RoomClassID { get; set; }
       
        public int BedTypeID { get; set; }
        
        public short BedsNumber { get; set; }

        public RoomClassBedTypeDTO(int roomClassBedTypeID, int roomClassID, int bedTypeID, short bedsNumber)
        {
            RoomClassBedTypeID = roomClassBedTypeID;
            RoomClassID = roomClassID;
            BedTypeID = bedTypeID;
            BedsNumber = bedsNumber;
        }
    }

    public class RoomClassBedTypesListDTO
    {
        public int RoomClassBedTypeID { get; set; }
        public int RoomClassID { get; set; }

        public string RoomClassName { get; set; }

        public float BasePrice { get; set; }

        public int BedTypeID { get; set; }
        public string BedTypeName { get; set; }
        public short BedsNumber { get; set; }

        public RoomClassBedTypesListDTO(int roomClassBedTypeID, int roomClassID, string roomClassName,
            float basePrice, int bedTypeID, string bedTypeName, short bedsNumber)
        {
            RoomClassBedTypeID = roomClassBedTypeID;
            RoomClassID = roomClassID;
            RoomClassName = roomClassName;
            BasePrice = basePrice;
            BedTypeID = bedTypeID;
            BedTypeName = bedTypeName;
            BedsNumber = bedsNumber;
        }
    }

    public class BedTypesForRoomClassListDTO
    {
        public int RoomClassBedTypeID { get; set; }
        

        public int BedTypeID { get; set; }
        public string BedTypeName { get; set; }
        public short BedsNumber { get; set; }

        public BedTypesForRoomClassListDTO(int roomClassBedTypeID, int bedTypeID, string bedTypeName,
            short bedsNumber)
        {
            RoomClassBedTypeID = roomClassBedTypeID;
            BedTypeID = bedTypeID;
            BedTypeName = bedTypeName;
            BedsNumber = bedsNumber;
        }
    }


    public class clsRoomClassBedTypeData
    {
        public static int AddNewRoomClassBedType(RoomClassBedTypeDTO roomClassBedTypeDTO)
        {
            int RoomClassBedTypeID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewRoomClassBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@RoomClassID", roomClassBedTypeDTO.RoomClassID);
                        Command.Parameters.AddWithValue("@BedTypeID", roomClassBedTypeDTO.BedTypeID);
                        Command.Parameters.AddWithValue("@BedsNumber", roomClassBedTypeDTO.BedsNumber);


                        SqlParameter outputIdParam = new SqlParameter("@NewRoomClassBedTypeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        RoomClassBedTypeID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                RoomClassBedTypeID = -1;
            }
            return RoomClassBedTypeID;
        }

        public static bool UpdateRoomClassBedType(RoomClassBedTypeDTO roomClassBedTypeDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateRoomClassBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassBedTypeID", roomClassBedTypeDTO.RoomClassBedTypeID);
                        Command.Parameters.AddWithValue("@RoomClassID", roomClassBedTypeDTO.RoomClassID);
                        Command.Parameters.AddWithValue("@BedTypeID", roomClassBedTypeDTO.BedTypeID);
                        Command.Parameters.AddWithValue("@BedsNumber", roomClassBedTypeDTO.BedsNumber);



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

        public static bool DeleteRoomClassBedType(int RoomClassBedTypeID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteRoomClassBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassBedTypeID", RoomClassBedTypeID);


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

        public static List<RoomClassBedTypesListDTO> GetAllRoomClassBedTypes()
        {
            List<RoomClassBedTypesListDTO> roomClassBedTypesLists = new List<RoomClassBedTypesListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllRoomClassBedType", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                roomClassBedTypesLists.Add(new RoomClassBedTypesListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassBedTypeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetString(Reader.GetOrdinal("RoomClassName")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("BasePrice")),
                                    Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                     Reader.GetString(Reader.GetOrdinal("BedTypeName")),
                                    Reader.GetByte(Reader.GetOrdinal("BedsNumber"))
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

            return roomClassBedTypesLists;
        }

        public static List<BedTypesForRoomClassListDTO> GetAllBedTypesForRoomClass(int RoomClassID)
        {
            List<BedTypesForRoomClassListDTO> bedTypesForRoomClassesList = new List<BedTypesForRoomClassListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllBedTypesForRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                bedTypesForRoomClassesList.Add(new BedTypesForRoomClassListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassBedTypeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                     Reader.GetString(Reader.GetOrdinal("BedTypeName")),
                                    Reader.GetByte(Reader.GetOrdinal("BedsNumber"))
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

            return bedTypesForRoomClassesList;
        }

        public static bool IsRoomClassBedTypeExistByBedTypeAndRoomClass(int BedTypeID,int RoomClassID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsRoomClassBedTypeExistByBedTypeAndRoomClass", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassID", RoomClassID);
                        Command.Parameters.AddWithValue("@BedTypeID", BedTypeID);
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

        public static RoomClassBedTypeDTO GetRoomClassBedTypeInfoByID( int RoomClassBedTypeID)
        {
            RoomClassBedTypeDTO roomClassBedTypeDTO = null;   
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetRoomClassBedTypeInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@RoomClassBedTypeID", RoomClassBedTypeID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                roomClassBedTypeDTO = new RoomClassBedTypeDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassBedTypeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("RoomClassID")),
                                    Reader.GetInt32(Reader.GetOrdinal("BedTypeID")),
                                    Reader.GetByte(Reader.GetOrdinal("BedsNumber"))
                                    );


                            }
                            else
                                roomClassBedTypeDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                roomClassBedTypeDTO = null;
            }
            return roomClassBedTypeDTO;

        }


    }

}
