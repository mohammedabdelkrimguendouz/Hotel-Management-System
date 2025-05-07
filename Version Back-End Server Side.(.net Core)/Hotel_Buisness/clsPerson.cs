using DVLD_DataAccess;
using Hotel_Buisness;
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

        public PersonDTO personDTO
        {
            get => new PersonDTO(this.PersonID,this.NationalNo,this.Gender,this.FirstName,this.MidlleName,
                this.LastName,this.Email,this.Phone,this.Address,this.DateOfBirth,this.NationalityCountryID);
        }
        
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

        public clsCountry CountryInfo;
        public string FullName
        {
            get { return FirstName + " " + MidlleName + " " + LastName; }
        }
        
        protected clsPerson(PersonDTO personDTO,enMode CreationMode=enMode.AddNew)

        {
            this.PersonID = personDTO.PersonID;
            this.NationalNo = personDTO.NationalNo;
            this.FirstName = personDTO.FirstName;
            this.MidlleName = personDTO.MidlleName;
            this.LastName = personDTO.LastName;
            this.Email = personDTO.Email;
            this.Phone = personDTO.Phone;
            this.Address = personDTO.Address;
            this.Gender = personDTO.Gender;
            this.DateOfBirth = personDTO.DateOfBirth;
            this.NationalityCountryID = personDTO.NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            Mode = CreationMode;
        }



        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(personDTO);
            return (this.PersonID != -1);
        }

        public static clsPerson Find(int PersonID)
        {
            PersonDTO personDTO = clsPersonData.GetPersonInfoByID(PersonID);


            if (personDTO!=null)
            {
                return new clsPerson(personDTO,enMode.Update);

            }
            return null;

        }

        public static clsPerson Find(string NationalNo)
        {

            PersonDTO personDTO = clsPersonData.GetPersonInfoByNationalNo(NationalNo);


            if (personDTO != null)
            {
                return new clsPerson(personDTO, enMode.Update);

            }
            return null;

        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(personDTO);
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
