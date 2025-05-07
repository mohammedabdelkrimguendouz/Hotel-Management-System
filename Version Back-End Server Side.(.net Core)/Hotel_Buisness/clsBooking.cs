using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsBooking
    {
        public enum enBookingStatus { Pending =0, Cancelled =1, Completed =2}
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public BookingDTO bookingDTO
        {
            get => new BookingDTO(this.BookingID, this.GuestID, this.PaymentID, this.BookingStatus, this.CheckInDate,
                this.CheckOutDate, this.NumberAdults, this.NumberChildren, this.BookingAmount, this.Discount,
                this.CreatedByEmployeeID);
        }
        public int BookingID { get; set; }
        public int GuestID { get; set; }

        public clsGuest GuestInfo;
        public int PaymentID { get; set; }
        public clsPayment PaymentInfo;
        public byte BookingStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public byte NumberAdults { get; set; }
        public byte NumberChildren { get; set; }
        public float BookingAmount { get; set; }
        public float Discount { get; set; }
        public int CreatedByEmployeeID { get; set; }
        public clsEmployee CreatedByEmployeeInfo;

        public clsBooking(BookingDTO bookingDTO,enMode CreationMode=enMode.AddNew)
        {
            this.BookingID = bookingDTO.BookingID;
            this.GuestID = bookingDTO.GuestID;
            this.GuestInfo = clsGuest.FindByGuestID(GuestID);
            this.PaymentID = bookingDTO.PaymentID;
            this.PaymentInfo = clsPayment.Find(PaymentID);
            this.BookingStatus = bookingDTO.BookingStatus;
            this.CheckInDate = bookingDTO.CheckInDate;
            this.CheckOutDate = bookingDTO.CheckOutDate;
            this.NumberAdults = bookingDTO.NumberAdults;
            this.NumberChildren = bookingDTO.NumberChildren;
            this.BookingAmount = bookingDTO.BookingAmount;
            this.Discount = bookingDTO.Discount;
            this.CreatedByEmployeeID = bookingDTO.CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = CreationMode;
        }

       

        public static clsBooking Find(int BookingID)
        {

            BookingDTO bookingDTO = clsBookingData.GetBookingInfoByID(BookingID);

            if (bookingDTO!=null)
            {
                return new clsBooking(bookingDTO,enMode.Update);

            }
            return null;

        }

        private bool _AddNewBooking()
        {
            this.BookingID = clsBookingData.AddNewBooking(bookingDTO);
            return (this.BookingID != -1);
        }

        private bool _UpdateBooking()
        {
            return clsBookingData.UpdateBooking(bookingDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBooking())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateBooking();
            }
            return false;
        }

        public static bool DeleteBooking(int BookingID)
        {
            return clsBookingData.DeleteBooking(BookingID);
        }

        public static List<BookingsListDTO> GetAllBookings()
        {
            return clsBookingData.GetAllBookings();
        }


        public static bool DeosExistBookingActiveForGuest(int GuestID)
        {
            return clsBookingData.DeosExistBookingActiveForGuest(GuestID);
        }


        public static float CalculateDiscount(int LoyaltyPoints,float Amount)
        {
            float DiscountRate = 0;
            if (LoyaltyPoints > 3 && LoyaltyPoints <= 6)
                DiscountRate = 0.05f;
            else if (LoyaltyPoints > 6 && LoyaltyPoints <= 10)
                DiscountRate = 0.10f;
            else if (LoyaltyPoints > 10 && LoyaltyPoints <= 15)
                DiscountRate = 0.15f;
            else if(LoyaltyPoints>20)
                DiscountRate = 0.20f;

            return DiscountRate * Amount;

        }
        public static bool IsBookingExist(int BookingID)
        {
            return clsBookingData.IsBookingExist(BookingID);
        }

        public static List<BookingsListDTO> GetAllBookingsForPageNumber(int PageNumber)
        {
            return clsBookingData.GetAllBookingsForPageNumber(PageNumber);
        }

        public bool SetCancel()
        {
            return clsBookingData.SetCancelBooking(this.BookingID);
        }

        public static bool UpdateAllBookingStatusIfCompleted()
        {
            return clsBookingData.UpdateAllBookingStatusIfCompleted();
        }
    }
}
