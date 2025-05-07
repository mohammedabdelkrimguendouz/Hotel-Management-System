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
    public class PersonDTO
    {
        public int PersonID { set; get; }
        public string NationalNo { set; get; }

        public byte Gender { set; get; }
        public string FirstName { set; get; }
        public string MidlleName { set; get; }

        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public int NationalityCountryID { set; get; }

        public PersonDTO(int personID, string nationalNo, byte gender, string firstName, 
            string midlleName, string lastName, string email, string phone, string address, 
            DateTime dateOfBirth, int nationalityCountryID)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            Gender = gender;
            FirstName = firstName;
            MidlleName = midlleName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            NationalityCountryID = nationalityCountryID;
        }
    }


    public class clsPersonData
    {
        public static int AddNewPerson(PersonDTO personDTO)
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

                        Command.Parameters.AddWithValue("@NationalNo", personDTO.NationalNo);
                        Command.Parameters.AddWithValue("@FirstName", personDTO.FirstName);


                        if (personDTO.MidlleName != "" && personDTO.MidlleName != null)
                            Command.Parameters.AddWithValue("@MidlleName", personDTO.MidlleName);
                        else
                            Command.Parameters.AddWithValue("@MidlleName", DBNull.Value);

                        

                        Command.Parameters.AddWithValue("@LastName", personDTO.LastName);
                        
                        if (personDTO.Email != "" && personDTO.Email != null)
                            Command.Parameters.AddWithValue("@Email", personDTO.Email);
                        else
                            Command.Parameters.AddWithValue("@Email", DBNull.Value);

                        Command.Parameters.AddWithValue("@Phone", personDTO.Phone);

                        if (personDTO.Address != "" && personDTO.Address != null)
                            Command.Parameters.AddWithValue("@Address", personDTO.Address);
                        else
                            Command.Parameters.AddWithValue("@Address", DBNull.Value);

                        
                        Command.Parameters.AddWithValue("@Gender", personDTO.Gender);
                        Command.Parameters.AddWithValue("@DateOfBirth", personDTO.DateOfBirth);
                        Command.Parameters.AddWithValue("@NationalityCountryID", personDTO.NationalityCountryID);

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


        public static PersonDTO GetPersonInfoByID(int PersonID)
        {
            PersonDTO personDTO = null;
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

                                personDTO = new PersonDTO(

                               Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                               Reader.GetString(Reader.GetOrdinal("NationalNo")),
                               Reader.GetByte(Reader.GetOrdinal("Gender")),
                               Reader.GetString(Reader.GetOrdinal("FirstName")),
                               Reader.IsDBNull(Reader.GetOrdinal("MidlleName")) ? "" : Reader.GetString(Reader.GetOrdinal("MidlleName")),
                               Reader.GetString(Reader.GetOrdinal("LastName")),
                               Reader.IsDBNull(Reader.GetOrdinal("Email")) ?"":Reader.GetString(Reader.GetOrdinal("Email")),
                               Reader.GetString(Reader.GetOrdinal("Phone")),
                               Reader.IsDBNull(Reader.GetOrdinal("Address")) ?"":Reader.GetString(Reader.GetOrdinal("Address")),
                               Reader.GetDateTime(Reader.GetOrdinal("DateOfBirth")),
                               Reader.GetInt32(Reader.GetOrdinal("NationalityCountryID"))
                               );
                               
                            }
                            else
                                personDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                personDTO = null;
            }
            return personDTO;

        }

        public static PersonDTO GetPersonInfoByNationalNo(string NationalNo)
        {
            PersonDTO personDTO = null;
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

                                personDTO = new PersonDTO(

                               Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                               Reader.GetString(Reader.GetOrdinal("NationalNo")),
                               Reader.GetByte(Reader.GetOrdinal("Gender")),
                               Reader.GetString(Reader.GetOrdinal("FirstName")),
                               Reader.IsDBNull(Reader.GetOrdinal("MidlleName")) ? "" : Reader.GetString(Reader.GetOrdinal("MidlleName")),
                               Reader.GetString(Reader.GetOrdinal("LastName")),
                               Reader.IsDBNull(Reader.GetOrdinal("Email")) ? "" : Reader.GetString(Reader.GetOrdinal("Email")),
                               Reader.GetString(Reader.GetOrdinal("Phone")),
                               Reader.IsDBNull(Reader.GetOrdinal("Address")) ? "" : Reader.GetString(Reader.GetOrdinal("Address")),
                               Reader.GetDateTime(Reader.GetOrdinal("DateOfBirth")),
                               Reader.GetInt32(Reader.GetOrdinal("NationalityCountryID"))
                               );

                            }
                            else
                                personDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                personDTO = null;
            }
            return personDTO;
        }

        public static bool UpdatePerson(PersonDTO personDTO)
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
                        Command.Parameters.AddWithValue("@NationalNo", personDTO.NationalNo);
                        Command.Parameters.AddWithValue("@FirstName", personDTO.FirstName);


                        if (personDTO.MidlleName != "" && personDTO.MidlleName != null)
                            Command.Parameters.AddWithValue("@MidlleName", personDTO.MidlleName);
                        else
                            Command.Parameters.AddWithValue("@MidlleName", DBNull.Value);



                        Command.Parameters.AddWithValue("@LastName", personDTO.LastName);

                        if (personDTO.Email != "" && personDTO.Email != null)
                            Command.Parameters.AddWithValue("@Email", personDTO.Email);
                        else
                            Command.Parameters.AddWithValue("@Email", DBNull.Value);

                        Command.Parameters.AddWithValue("@Phone", personDTO.Phone);

                        if (personDTO.Address != "" && personDTO.Address != null)
                            Command.Parameters.AddWithValue("@Address", personDTO.Address);
                        else
                            Command.Parameters.AddWithValue("@Address", DBNull.Value);


                        Command.Parameters.AddWithValue("@Gender", personDTO.Gender);
                        Command.Parameters.AddWithValue("@DateOfBirth", personDTO.DateOfBirth);
                        Command.Parameters.AddWithValue("@NationalityCountryID", personDTO.NationalityCountryID);


                        Command.Parameters.AddWithValue("@PersonID", personDTO.PersonID);


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
