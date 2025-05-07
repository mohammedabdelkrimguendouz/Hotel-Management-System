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
    public class clsPersonData
    {
        public static int AddNewPerson(string NationalNo, string FirstName, string MidlleName, string LastName, string Email, string Phone,
    string Address, short Gender, DateTime DateOfBirth, int NationalityCountryID)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("SP_AddNewPerson", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        Command.Parameters.AddWithValue("@FirstName", FirstName);


                        if (MidlleName != "" && MidlleName != null)
                            Command.Parameters.AddWithValue("@MidlleName", MidlleName);
                        else
                            Command.Parameters.AddWithValue("@MidlleName", DBNull.Value);

                        

                        Command.Parameters.AddWithValue("@LastName", LastName);
                        
                        if (Email != "" && Email != null)
                            Command.Parameters.AddWithValue("@Email", Email);
                        else
                            Command.Parameters.AddWithValue("@Email", DBNull.Value);

                        Command.Parameters.AddWithValue("@Phone", Phone);

                        if (Address != "" && Address != null)
                            Command.Parameters.AddWithValue("@Address", Address);
                        else
                            Command.Parameters.AddWithValue("@Address", DBNull.Value);

                        
                        Command.Parameters.AddWithValue("@Gender", Gender);
                        Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        PersonID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                PersonID = -1;
            }
            return PersonID;
        }


        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string MidlleName, ref string LastName, ref string Email, ref string Phone,
        ref string Address, ref short Gender, ref DateTime DateOfBirth, ref int NationalityCountryID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetPersonInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;


                                NationalNo = (string)Reader["NationalNo"];
                                FirstName = (string)Reader["FirstName"];
                                MidlleName = (Reader["MidlleName"] == DBNull.Value) ? "" : (string)Reader["MidlleName"];
                                LastName = (string)Reader["LastName"];
                                Email = (Reader["Email"] == DBNull.Value) ? "" : (string)Reader["Email"];
                                Phone = (string)Reader["Phone"];
    
                                Gender = (byte)Reader["Gender"];
                                DateOfBirth = (DateTime)Reader["DateOfBirth"];
                                NationalityCountryID = (int)Reader["NationalityCountryID"];
                                Address = (Reader["Address"] == DBNull.Value) ? "" : (string)Reader["Address"];
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

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string MidlleName, ref string LastName, ref string Email, ref string Phone,
        ref string Address, ref short Gender, ref DateTime DateOfBirth, ref int NationalityCountryID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetPersonInfoByNationalNo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)Reader["PersonID"];
                                FirstName = (string)Reader["FirstName"];
                                MidlleName = (Reader["MidlleName"] == DBNull.Value) ? "" : (string)Reader["MidlleName"];
                                LastName = (string)Reader["LastName"];
                                Email = (Reader["Email"] == DBNull.Value) ? "" : (string)Reader["Email"];
                                Phone = (string)Reader["Phone"];
                                Gender = (byte)Reader["Gender"];
                                DateOfBirth = (DateTime)Reader["DateOfBirth"];
                                NationalityCountryID = (int)Reader["NationalityCountryID"];
                                Address = (Reader["Address"] == DBNull.Value) ? "" : (string)Reader["Address"];
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

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string MidlleName, string LastName, string Email, string Phone,
        string Address, short Gender, DateTime DateOfBirth, int NationalityCountryID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdatePerson", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        Command.Parameters.AddWithValue("@FirstName", FirstName);


                        if (MidlleName != "" && MidlleName != null)
                            Command.Parameters.AddWithValue("@MidlleName", MidlleName);
                        else
                            Command.Parameters.AddWithValue("@MidlleName", DBNull.Value);



                        Command.Parameters.AddWithValue("@LastName", LastName);

                        if (Email != "" && Email != null)
                            Command.Parameters.AddWithValue("@Email", Email);
                        else
                            Command.Parameters.AddWithValue("@Email", DBNull.Value);

                        Command.Parameters.AddWithValue("@Phone", Phone);

                        if (Address != "" && Address != null)
                            Command.Parameters.AddWithValue("@Address", Address);
                        else
                            Command.Parameters.AddWithValue("@Address", DBNull.Value);


                        Command.Parameters.AddWithValue("@Gender", Gender);
                        Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


                        Command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool DeletePerson(int PersonID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeletePerson", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PersonID", PersonID);

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

       

        public static bool IsPersonExistByID(int PersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsPersonExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsPersonExistByNationalNo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
