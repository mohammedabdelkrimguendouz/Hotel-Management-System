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
    public class AllGuestInfoDTO
    {
        public int GuestID { get; set; }

        public short LoyaltyPoints { get; private set; }
        public int CreatedByEmployeeID { get; set; }
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

        public AllGuestInfoDTO(int guestID, short loyaltyPoints, int createdByEmployeeID, 
            int personID, string nationalNo, byte gender, string firstName, string midlleName,
            string lastName, string email, string phone, string address, DateTime dateOfBirth,
            int nationalityCountryID)
        {
            GuestID = guestID;
            LoyaltyPoints = loyaltyPoints;
            CreatedByEmployeeID = createdByEmployeeID;
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
    public class clsGuest : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public GuestDTO guestDTO
        {
            get => new GuestDTO(this.GuestID, this.PersonID, this.LoyaltyPoints, this.CreatedByEmployeeID);
        }

        public AllGuestInfoDTO allGuestInfoDTO
        {
            get => new AllGuestInfoDTO(this.GuestID,this.LoyaltyPoints,this.CreatedByEmployeeID,
                this.PersonID,this.NationalNo,this.Gender,this.FirstName,this.MidlleName,this.LastName,this.Email,
                this.Phone,this.Address,this.DateOfBirth,this.NationalityCountryID);
        }

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

        public clsGuest(GuestDTO guestDTO,PersonDTO personDTO,enMode CreationMode=enMode.AddNew)
            : base(personDTO,(clsPerson.enMode)CreationMode)
        {
            this.PersonID = guestDTO.PersonID;
            this.GuestID = guestDTO.GuestID;
            this.CreatedByEmployeeID = guestDTO.CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            this.LoyaltyPoints = guestDTO.LoyaltyPoints;
            Mode = CreationMode;
        }

       
        public static clsGuest FindByGuestID(int GuestID)
        {

            

            GuestDTO guestDTO = clsGuestData.GetGuestInfoByID(GuestID);

            if(guestDTO!=null)
            {
                clsPerson Person = clsPerson.Find(guestDTO.PersonID);
                if (Person != null)
                    return new clsGuest(guestDTO,Person.personDTO,enMode.Update);
            }

            
            return null;

        }

        public static clsGuest FindByNationalNo(string NationalNo)
        {

            GuestDTO guestDTO = clsGuestData.GetGuestInfoByNationalNo(NationalNo);

            if (guestDTO != null)
            {
                clsPerson Person = clsPerson.Find(guestDTO.PersonID);
                if (Person != null)
                    return new clsGuest(guestDTO, Person.personDTO, enMode.Update);
            }


            return null;

        }

        private bool _AddNewGuest()
        {
            this.GuestID = clsGuestData.AddNewGuest(guestDTO);
            return (this.GuestID != -1);

        }

        private bool _UpdateGuest()
        {
            return clsGuestData.UpdateGuest(guestDTO);
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

        public static List<GuestsListDTO> GetAllGuests()
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
        public static List<GuestsListDTO>  GetAllGuestsForPageNumber(int PageNumber)
        {
            return clsGuestData.GetAllGuestsForPageNumber(PageNumber);
        }
    }
}
