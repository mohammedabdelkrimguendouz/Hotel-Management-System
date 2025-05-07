using DVLD_Buisness;
using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class AllEmployeeInfoDTO
    {
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte[]? Image { get; set; }

        public float Salary { get; set; }

        public int PersonID { set; get; }
        public string NationalNo { set; get; }

        public byte Gender { set; get; }
        public string FirstName { set; get; }
        public string? MidlleName { set; get; }

        public string LastName { set; get; }
        public string? Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public int NationalityCountryID { set; get; }

        public AllEmployeeInfoDTO(int employeeID, DateTime hireDate, DateTime? endDate, string userName,
            string password, bool isActive, byte[]? image, float salary, int personID, string nationalNo,
            byte gender, string firstName, string midlleName, string lastName, string? email, string phone, 
            string address, DateTime dateOfBirth, int nationalityCountryID)
        {
            EmployeeID = employeeID;
            HireDate = hireDate;
            EndDate = endDate;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Image = image;
            Salary = salary;
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
        public AllEmployeeInfoDTO() { }
    }
    public class clsEmployee :clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;

        public AllEmployeeInfoDTO allEmployeeInfoDTO
        {
            get => new AllEmployeeInfoDTO(this.EmployeeID,this.HireDate,this.EndDate,this.UserName,this.Password,
                this.IsActive,this.Image,this.Salary,this.PersonID,this.NationalNo,this.Gender,this.FirstName,
                this.MidlleName,this.LastName,this.Email,this.Phone,this.Address,this.DateOfBirth,
                this.NationalityCountryID);
        }
        public EmployeeDTO employeeDTO
        {
            get => new EmployeeDTO(this.EmployeeID, this.PersonID, this.HireDate, this.EndDate,
                this.UserName, this.Password, this.IsActive, this.Image, this.Salary);
        }
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte[] Image { get; set; }

        public float Salary {  get; set; }

        public clsEmployee(EmployeeDTO employeeDTO,PersonDTO personDTO,enMode CreationMode=enMode.AddNew)
            :base(personDTO,(clsPerson.enMode)CreationMode)
        {
            this.PersonID = employeeDTO.PersonID;
            this.EmployeeID = employeeDTO.EmployeeID;
            this.HireDate = employeeDTO.HireDate;
            this.EndDate = employeeDTO.EndDate;
            this.UserName = employeeDTO.UserName;
            this.Password = employeeDTO.Password;
            this.IsActive = employeeDTO.IsActive;
            this.Image = employeeDTO.Image;
            this.Salary = employeeDTO.Salary;
            Mode = CreationMode;
        }

        

        public static clsEmployee FindByEmployeeID(int EmployeeID)
        {

            
            EmployeeDTO employeeDTO = clsEmployeeData.GetEmployeeInfoByID
                (EmployeeID);


            if (employeeDTO!=null)
            {
                clsPerson Person = clsPerson.Find(employeeDTO.PersonID);
                if(Person!=null)
                    return new clsEmployee(employeeDTO,Person.personDTO,enMode.Update);

            }
                    

            return null;

            
        }

        public static clsEmployee FindByUserNameAndPassword(string UserName,string Password)
        {
            EmployeeDTO employeeDTO = clsEmployeeData.GetEmployeeInfoByUserNameAndPassword
               (UserName, Password);


            if (employeeDTO != null)
            {
                clsPerson Person = clsPerson.Find(employeeDTO.PersonID);
                if (Person != null)
                    return new clsEmployee(employeeDTO, Person.personDTO, enMode.Update);

            }


            return null;


        }

        public static clsEmployee FindByNationalNo(string NationalNo)
        {

            EmployeeDTO employeeDTO = clsEmployeeData.GetEmployeeInfoByNationalNo
               (NationalNo);


            if (employeeDTO != null)
            {
                clsPerson Person = clsPerson.Find(employeeDTO.PersonID);
                if (Person != null)
                    return new clsEmployee(employeeDTO, Person.personDTO, enMode.Update);

            }


            return null;


        }

        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeData.AddNewEmployee(this.employeeDTO);
            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(employeeDTO);
        }

        public bool Save()
        {

            base.Mode = (clsPerson.enMode)Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateEmployee();
            }
            return false;
        }

        static public bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeeData.DeleteEmployee(EmployeeID);
        }

        public static List<EmployeesListDTO> GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }

        public static bool IsEmployeeExist(int EmployeeID)
        {
            return clsEmployeeData.IsEmployeeExist(EmployeeID);
        }
        static public bool IsEmployeeExist(string UserName)
        {
            return clsEmployeeData.IsEmployeeExistByUserName(UserName);
        }
        public static bool IsEmployeeExistForPersonID(int PersonID)
        {
            return clsEmployeeData.IsEmployeeExistForPersonID(PersonID);
        }

        public static bool IsEmployeeExistForNationalNo(string NationalNo)
        {
            return clsEmployeeData.IsEmployeeExistForNationalNo(NationalNo);
        }

        

    }
}
