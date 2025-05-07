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

    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public int PersonID {  get; set; }
        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte[] Image { get; set; }

        public float Salary { get; set; }

        public EmployeeDTO(int employeeID, int personID, DateTime hireDate, DateTime? endDate,
            string userName, string password, bool isActive, byte[] image, float salary)
        {
            EmployeeID = employeeID;
            PersonID = personID;
            HireDate = hireDate;
            EndDate = endDate;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Image = image;
            Salary = salary;
        }
    }

    public class EmployeesListDTO
    {
        public int EmployeeID { get; set; }
        public int PersonID { get; set; }

        public string FullName {  get; set; }

        public string UserName { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
       
       
        public bool IsActive { get; set; }

        public EmployeesListDTO(int employeeID, int personID, string fullName, 
            string userName, DateTime hireDate, DateTime? endDate, bool isActive)
        {
            EmployeeID = employeeID;
            PersonID = personID;
            FullName = fullName;
            UserName = userName;
            HireDate = hireDate;
            EndDate = endDate;
            IsActive = isActive;
        }
    }

    public class clsEmployeeData
    {
        public static int AddNewEmployee(EmployeeDTO employeeDTO)
        {
            int EmployeeID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_AddNewEmployee", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        
                        Command.Parameters.AddWithValue("@PersonID", employeeDTO.PersonID);
                        Command.Parameters.AddWithValue("@HireDate", employeeDTO.HireDate);
                        Command.Parameters.AddWithValue("@UserName", employeeDTO.UserName);
                        Command.Parameters.AddWithValue("@Password", employeeDTO.Password);
                        Command.Parameters.AddWithValue("@IsActive", employeeDTO.IsActive);
                        Command.Parameters.AddWithValue("@Salary", employeeDTO.Salary);
                        Command.Parameters.AddWithValue("@Image", employeeDTO.Image);
                        

                        SqlParameter outputIdParam = new SqlParameter("@NewEmployeeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(outputIdParam);


                        Command.ExecuteNonQuery();

                        EmployeeID = (int)outputIdParam.Value;

                    }
                }

            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                EmployeeID = -1;
            }
            return EmployeeID;
        }

        public static bool UpdateEmployee(EmployeeDTO employeeDTO)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_UpdateEmployee", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@EmployeeID", employeeDTO.EmployeeID);
                        Command.Parameters.AddWithValue("@PersonID", employeeDTO.PersonID);
                        Command.Parameters.AddWithValue("@HireDate", employeeDTO.HireDate);
                        Command.Parameters.AddWithValue("@UserName", employeeDTO.UserName);
                        Command.Parameters.AddWithValue("@Password", employeeDTO.Password);
                        Command.Parameters.AddWithValue("@IsActive", employeeDTO.IsActive);
                        Command.Parameters.AddWithValue("@Salary", employeeDTO.Salary);
                        Command.Parameters.AddWithValue("@Image", employeeDTO.Image);



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

        public static bool DeleteEmployee(int EmployeeID)
        {
            int RowsEffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_DeleteEmployee", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);


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

        public static bool IsEmployeeExist(int EmployeeID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsEmployeeExistByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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

        public static bool IsEmployeeExistByUserName(string UserName)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsEmployeeExistByUserName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UserName", UserName);
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

        public static bool IsEmployeeExistForPersonID(int PersonID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsEmployeeExistForPersonID", Connection))
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

        public static bool IsEmployeeExistForNationalNo(string NationalNo)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_IsEmployeeExistForNationalNo", Connection))
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


        public static EmployeeDTO GetEmployeeInfoByNationalNo(string NationalNo)
        {
            EmployeeDTO employeeDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetEmployeeInfoByNationalNo", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                employeeDTO = new EmployeeDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("EmployeeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("HireDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("EndDate")) ?null:Reader.GetDateTime(Reader.GetOrdinal("EndDate")),
                                    Reader.GetString(Reader.GetOrdinal("UserName")),
                                    Reader.GetString(Reader.GetOrdinal("Password")),
                                    Reader.GetBoolean(Reader.GetOrdinal("IsActive")),
                                    (byte[])Reader.GetValue(Reader.GetOrdinal("Image")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("Salary"))
                                   
                                    );
                               


                            }
                            else
                                employeeDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                employeeDTO = null;
            }
            return employeeDTO;

        }

        public static EmployeeDTO GetEmployeeInfoByUserNameAndPassword( string UserName,  string Password)
        {
            EmployeeDTO employeeDTO = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetEmployeeInfoByUserNameAndPassword", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                employeeDTO = new EmployeeDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("EmployeeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("HireDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("EndDate")) ? null : Reader.GetDateTime(Reader.GetOrdinal("EndDate")),
                                    Reader.GetString(Reader.GetOrdinal("UserName")),
                                    Reader.GetString(Reader.GetOrdinal("Password")),
                                    Reader.GetBoolean(Reader.GetOrdinal("IsActive")),
                                    (byte[])Reader.GetValue(Reader.GetOrdinal("Image")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("Salary"))

                                    );



                            }
                            else
                                employeeDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                employeeDTO = null;
            }
            return employeeDTO;

        }
        public static EmployeeDTO GetEmployeeInfoByID( int EmployeeID)
        {
            EmployeeDTO employeeDTO =null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetEmployeeInfoByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                employeeDTO = new EmployeeDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("EmployeeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetDateTime(Reader.GetOrdinal("HireDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("EndDate")) ? null : Reader.GetDateTime(Reader.GetOrdinal("EndDate")),
                                    Reader.GetString(Reader.GetOrdinal("UserName")),
                                    Reader.GetString(Reader.GetOrdinal("Password")),
                                    Reader.GetBoolean(Reader.GetOrdinal("IsActive")),
                                    (byte[])Reader.GetValue(Reader.GetOrdinal("Image")),
                                    (float)Reader.GetDecimal(Reader.GetOrdinal("Salary"))

                                    );



                            }
                            else
                                employeeDTO = null;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                employeeDTO = null;
            }
            return employeeDTO;

        }

        public static List<EmployeesListDTO> GetAllEmployees()
        {
            List<EmployeesListDTO> employeesLists=new List<EmployeesListDTO>();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("SP_GetAllEmployees", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                employeesLists.Add(new EmployeesListDTO(
                                    Reader.GetInt32(Reader.GetOrdinal("EmployeeID")),
                                    Reader.GetInt32(Reader.GetOrdinal("PersonID")),
                                    Reader.GetString(Reader.GetOrdinal("FullName")),
                                    Reader.GetString(Reader.GetOrdinal("UserName")),
                                    Reader.GetDateTime(Reader.GetOrdinal("HireDate")),
                                    Reader.IsDBNull(Reader.GetOrdinal("EndDate")) ? null : Reader.GetDateTime(Reader.GetOrdinal("EndDate")),
                                   
                                    Reader.GetBoolean(Reader.GetOrdinal("IsActive"))
                                    

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

            return employeesLists;
        }
    }
}
