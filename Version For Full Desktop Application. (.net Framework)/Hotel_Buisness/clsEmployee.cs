using DVLD_Buisness;
using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsEmployee :clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte[] Image { get; set; }

        public float Salary {  get; set; }

        private clsEmployee(int PersonID, string NationalNo, string FirstName, string MidlleName, string LastName,
            string Email, string Phone, string Address, enGender Gender, DateTime DateOfBirth, int NationalityCountryID,
            int EmployeeID, DateTime HireDate,DateTime? EndDate, string UserName,
            string Password, bool IsActive, byte[] Image,float Salary)
            :base( PersonID,  NationalNo,  FirstName,  MidlleName,  LastName,
             Email,  Phone,  Address,  Gender,  DateOfBirth,  NationalityCountryID)
        {

            this.EmployeeID = EmployeeID;
            this.HireDate = HireDate;
            this.EndDate = EndDate;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Image = Image;
            this.Salary = Salary;
            Mode = enMode.Update;
        }

        public clsEmployee()
        {
            EmployeeID = -1;
            PersonID = -1;
            HireDate = DateTime.Now;
            EndDate = null;
            UserName = "";
            Password = "";
            IsActive = false;
            this.Image = null;
            Salary = 0.0f;
            Mode = enMode.AddNew;
        }

        public static clsEmployee FindByEmployeeID(int EmployeeID)
        {

            int PersonID = -1; DateTime HireDate = DateTime.Now; DateTime? EndDate = null;
            string UserName = "", Password = ""; bool IsActive = false; byte[] Image = null;
            float Salary = 0.0f;
            bool IsFound = clsEmployeeData.GetEmployeeInfoByID
                (EmployeeID, ref PersonID, ref HireDate,ref EndDate,ref UserName,ref Password,ref IsActive,ref Image,ref Salary);


            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if(Person!=null)
                    return new clsEmployee(Person.PersonID, Person.NationalNo, Person.FirstName, Person.MidlleName, Person.LastName,
                        Person.Email, Person.Phone, Person.Address, Person.Gender, Person.DateOfBirth, Person.NationalityCountryID
                        ,EmployeeID, HireDate, EndDate, UserName,
                      Password, IsActive, Image, Salary);

            }
                    

            return null;

            
        }

        public static clsEmployee FindByUserNameAndPassword(string UserName,string Password)
        {
            int EmployeeID = -1;    
            int PersonID = -1; DateTime HireDate = DateTime.Now; DateTime? EndDate = null;
           bool IsActive = false; byte[] Image = null;
            float Salary = 0.0f;
            bool IsFound = clsEmployeeData.GetEmployeeInfoByUserNameAndPassword
                ( UserName,  Password, ref EmployeeID, ref PersonID, ref HireDate, ref EndDate,  ref IsActive, ref Image,ref Salary);


            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if (Person != null)
                    return new clsEmployee(Person.PersonID, Person.NationalNo, Person.FirstName, Person.MidlleName, Person.LastName,
                        Person.Email, Person.Phone, Person.Address, Person.Gender, Person.DateOfBirth, Person.NationalityCountryID
                        , EmployeeID, HireDate, EndDate, UserName,
                      Password, IsActive, Image,Salary);

            }


            return null;


        }

        public static clsEmployee FindByNationalNo(string NationalNo)
        {

            int PersonID = -1, EmployeeID=-1; DateTime HireDate = DateTime.Now; DateTime? EndDate = null;
            string UserName = "", Password = ""; bool IsActive = false; byte[] Image = null;
            float Salary = 0.0f;
            bool IsFound = clsEmployeeData.GetEmployeeInfoByNationalNo
                (NationalNo,ref EmployeeID, ref PersonID, ref HireDate, ref EndDate, ref UserName, ref Password, ref IsActive, ref Image,ref Salary);


            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if (Person != null)
                    return new clsEmployee(Person.PersonID, Person.NationalNo, Person.FirstName, Person.MidlleName, Person.LastName,
                        Person.Email, Person.Phone, Person.Address, Person.Gender, Person.DateOfBirth, Person.NationalityCountryID
                        , EmployeeID, HireDate, EndDate, UserName,
                      Password, IsActive, Image, Salary);

            }


            return null;


        }

        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeData.AddNewEmployee(PersonID, HireDate, UserName, Password, IsActive, Image,Salary);
            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(EmployeeID, PersonID, HireDate, UserName, Password, IsActive, Image, Salary);
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

        static public   bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeeData.DeleteEmployee(EmployeeID);
        }

        public static DataTable GetAllEmployees()
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
