using DVLD_Buisness;
using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel_Buisness
{
    public class clsGuest : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int GuestID { get; set; }
        
        public short LoyaltyPoints { get; private set; }
        public int CreatedByEmployeeID { get; set; }
        public clsEmployee CreatedByEmployeeInfo;

        public int NumberOfBookings
        {
            get
            {
                return clsGuestData.GetNumberOfBookings(this.GuestID);
            }
        }

        private clsGuest(int PersonID, string NationalNo, string FirstName, string MidlleName, string LastName,
            string Email, string Phone, string Address, enGender Gender, DateTime DateOfBirth, int NationalityCountryID,
            int GuestID, int CreatedByEmployeeID,short LoyaltyPoints)
            : base(PersonID, NationalNo, FirstName, MidlleName, LastName,
             Email, Phone, Address, Gender, DateOfBirth, NationalityCountryID)
        {
            this.GuestID = GuestID;
            this.CreatedByEmployeeID = CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            this.LoyaltyPoints = LoyaltyPoints;
            Mode = enMode.Update;
        }

        public clsGuest()
        {
            GuestID = -1;
            PersonID = -1;
            CreatedByEmployeeID = -1;
            LoyaltyPoints = 0;
            Mode = enMode.AddNew;
        }

        public static clsGuest FindByGuestID(int GuestID)
        {

            int PersonID = -1, CreatedByEmployeeID = -1;short LoyaltyPoints = 0;

            bool Found = clsGuestData.GetGuestInfoByID(GuestID, ref PersonID, ref CreatedByEmployeeID,ref LoyaltyPoints);

            if(Found)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if (Person != null)
                    return new clsGuest(Person.PersonID, Person.NationalNo, Person.FirstName, Person.MidlleName, Person.LastName,
                        Person.Email, Person.Phone, Person.Address, Person.Gender, Person.DateOfBirth, Person.NationalityCountryID
                        , GuestID,  CreatedByEmployeeID, LoyaltyPoints);
            }

            
            return null;

        }

        public static clsGuest FindByNationalNo(string NationalNo)
        {

            int PersonID = -1, CreatedByEmployeeID = -1,GuestID=-1;
            short LoyaltyPoints = 0;

            bool Found = clsGuestData.GetGuestInfoByNationalNo(NationalNo,ref GuestID, ref PersonID, ref CreatedByEmployeeID,ref LoyaltyPoints);

            if (Found)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if (Person != null)
                    return new clsGuest(Person.PersonID, Person.NationalNo, Person.FirstName, Person.MidlleName, Person.LastName,
                        Person.Email, Person.Phone, Person.Address, Person.Gender, Person.DateOfBirth, Person.NationalityCountryID
                        , GuestID, CreatedByEmployeeID, LoyaltyPoints);
            }


            return null;

        }

        private bool _AddNewGuest()
        {
            this.GuestID = clsGuestData.AddNewGuest(PersonID, CreatedByEmployeeID);
            return (this.GuestID != -1);

        }

        private bool _UpdateGuest()
        {
            return clsGuestData.UpdateGuest(GuestID, PersonID, CreatedByEmployeeID);
        }

        public bool Save()
        {
            base.Mode = (clsPerson.enMode)Mode;
            if (!base.Save())
                return false;


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGuest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateGuest();
            }
            return false;
        }

        public  bool DeleteGuest()
        {
            if (!clsGuestData.DeleteGuest(GuestID))
                return false;

            return base.DeletePerson();
        }

        public static DataTable GetAllGuests()
        {
            return clsGuestData.GetAllGuests();
        }

        public static bool IsGuestExistByGuestID(int GuestID)
        {
            return clsGuestData.IsGuestExistByGuestID(GuestID);
        }
        public static bool IsGuestExistForNationalNo(string NationalNo)
        {
            return clsGuestData.IsGuestExistForNationalNo(NationalNo);
        }
        public static DataTable GetAllGuestsForPageNumber(int PageNumber)
        {
            return clsGuestData.GetAllGuestsForPageNumber(PageNumber);
        }
    }
}
