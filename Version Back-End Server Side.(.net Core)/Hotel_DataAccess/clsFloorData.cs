
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
    public class FloorDTO
    {
        public int FloorID { get; set; }
        public byte FloorNumber { get; set; }
        public double FloorArea { get; set; }

        public FloorDTO(int floorID, byte floorNumber, double floorArea)
        {
            FloorID = floorID;
            FloorNumber = floorNumber;
            FloorArea = floorArea;
        }
    }

    public class FloorsListDTO
    {
        public int FloorID { get; set; }
        public byte FloorNumber { get; set; }
        public double FloorArea { get; set; }

        public int NumberOfRooms {  get; set; }

        public FloorsListDTO(int floorID, byte floorNumber, double floorArea, int numberOfRooms)
        {
            FloorID = floorID;
            FloorNumber = floorNumber;
            FloorArea = floorArea;
            NumberOfRooms = numberOfRooms;
        }
    }



    public class clsFloorData
    {
        public static int AddNewFloor(FloorDTO floorDTO)
        {
            int FloorID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewFloor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@FloorNumber", floorDTO.FloorNumber);
                        Command.Parameters.AddWithValue("@FloorArea", floorDTO.FloorArea);


                        SqlParameter outputIdParam = new SqlParameter("@NewFloorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        FloorID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                FloorID = -1;
            }
            return FloorID;
        }

        public static bool UpdateFloor(FloorDTO floorDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateFloor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FloorID", floorDTO.FloorID);
                        Command.Parameters.AddWithValue("@FloorNumber", floorDTO.FloorNumber);

                        Command.Parameters.AddWithValue("@FloorArea", floorDTO.FloorArea);



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

        public static bool DeleteFloor(int FloorID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteFloor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FloorID", FloorID);


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

        public static List<FloorsListDTO> GetAllFloors()
        {
            List<FloorsListDTO> floorsList=new List<FloorsListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllFloor", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while(Reader.Read())
                            {
                                floorsList.Add(new FloorsListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FloorID")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetDouble(Reader.GetOrdinal("FloorArea")),
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

            return floorsList;
        }

        public static FloorDTO GetFloorInfoByID( int FloorID)
        {
            FloorDTO floorDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetFloorInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FloorID", FloorID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if(Reader.Read())
                            {

                                floorDTO = new FloorDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FloorID")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetDouble(Reader.GetOrdinal("FloorArea"))
                                    );

                            }
                            else
                                floorDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                floorDTO = null;
            }
            return floorDTO ;

        }

        public static FloorDTO GetFloorInfoByFloorNumber(byte FloorNumber)
        {
            FloorDTO floorDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetFloorInfoByFloorNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FloorNumber", FloorNumber);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                floorDTO = new FloorDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("FloorID")),
                                    Reader.GetByte(Reader.GetOrdinal("FloorNumber")),
                                    Reader.GetDouble(Reader.GetOrdinal("FloorArea"))
                                    );

                            }
                            else
                                floorDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                floorDTO = null;
            }
            return floorDTO;

        }

        public static bool IsFloorNumberExist(byte FloorNumber)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsNumberFloorExist", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@FloorNumber", FloorNumber);
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
