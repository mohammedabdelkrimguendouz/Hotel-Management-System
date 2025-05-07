using DVLD_DataAccess;
using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsPerson
    {
        protected enum enMode { AddNew = 0,Update = 1  };
        protected enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 };
        
        public int PersonID { set; get; }
        public string NationalNo { set; get; }

        public enGender Gender { set; get; }
        public string FirstName { set; get; }
        public string MidlleName { set; get; }

        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public int NationalityCountryID { set; get; }

        public clsCountry CountryInfo;
        public string FullName
        {
            get { return FirstName + " " + MidlleName + " " + LastName; }
        }
        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            MidlleName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            Gender = enGender.Male;
            DateOfBirth = DateTime.Now.AddYears(-15);
            NationalityCountryID = -1;
            Mode = enMode.AddNew;
        }

        protected clsPerson(int PersonID, string NationalNo, string FirstName, string MidlleName, string LastName,
            string Email, string Phone, string Address, enGender Gender, DateTime DateOfBirth, int NationalityCountryID)

        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.MidlleName = MidlleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            Mode = enMode.Update;
        }



        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.MidlleName, this.LastName, this.Email, this.Phone,
                this.Address,(short) this.Gender, this.DateOfBirth, this.NationalityCountryID);
            return (this.PersonID != -1);
        }

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            string NationalNo = "", MidlleName = ""; short Gender = 0;
            DateTime DateOfBirth = DateTime.Now.AddYears(-15);
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref MidlleName, ref LastName, ref Email, ref Phone,
             ref Address, ref Gender, ref DateOfBirth, ref NationalityCountryID))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, MidlleName, LastName, Email, Phone,
               Address,(enGender) Gender, DateOfBirth, NationalityCountryID);

            }
            return null;

        }

        public static clsPerson Find(string NationalNo)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            int PersonID = -1; string MidlleName = ""; short Gender = 0;
            DateTime DateOfBirth = DateTime.Now.AddYears(-15);
            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo,ref PersonID, ref FirstName, ref MidlleName, ref LastName, ref Email, ref Phone,
             ref Address, ref Gender, ref DateOfBirth, ref NationalityCountryID))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, MidlleName, LastName, Email, Phone,
               Address,(enGender) Gender, DateOfBirth, NationalityCountryID);

            }
            return null;

        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID,this.NationalNo, this.FirstName, this.MidlleName, this.LastName, this.Email, this.Phone,
                this.Address,(short) this.Gender, this.DateOfBirth, this.NationalityCountryID);
        }

        protected bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }

        protected  bool DeletePerson()
        {
            return clsPersonData.DeletePerson(this.PersonID);
        }
      
        static public bool ISPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExistByID(PersonID);
        }
        static public bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExistByNationalNo(NationalNo);
        }
    }
}
