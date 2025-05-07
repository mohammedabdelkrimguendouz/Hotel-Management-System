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
        public int BookingID { get; set; }
        public int GuestID { get; set; }

        public clsGuest GuestInfo;
        public int PaymentID { get; set; }
        public clsPayment PaymentInfo;
        public enBookingStatus BookingStatus { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public short NumberAdults { get; set; }
        public short NumberChildren { get; set; }
        public float BookingAmount { get; set; }
        public float Discount { get; set; }
        public int CreatedByEmployeeID { get; set; }
        public clsEmployee CreatedByEmployeeInfo;

        private clsBooking(int BookingID, int GuestID, int PaymentID, enBookingStatus BookingStatus, DateTime CheckInDate, DateTime CheckOutDate, short NumberAdults, short NumberChildren, float BookingAmount, float Discount, int CreatedByEmployeeID)
        {
            this.BookingID = BookingID;
            this.GuestID = GuestID;
            this.GuestInfo = clsGuest.FindByGuestID(GuestID);
            this.PaymentID = PaymentID;
            this.PaymentInfo = clsPayment.Find(PaymentID);
            this.BookingStatus = BookingStatus;
            this.CheckInDate = CheckInDate;
            this.CheckOutDate = CheckOutDate;
            this.NumberAdults = NumberAdults;
            this.NumberChildren = NumberChildren;
            this.BookingAmount = BookingAmount;
            this.Discount = Discount;
            this.CreatedByEmployeeID = CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = enMode.Update;
        }

        public clsBooking()
        {
            BookingID = -1;
            GuestID = -1;
            PaymentID = -1;
            BookingStatus = enBookingStatus.Pending;
            CheckInDate = DateTime.Now;
            CheckOutDate = DateTime.Now;
            NumberAdults = 1;
            NumberChildren = 1;
            BookingAmount = 0;
            Discount = 0;
            CreatedByEmployeeID = -1;
            Mode = enMode.AddNew;
        }

        public static clsBooking Find(int BookingID)
        {

            int GuestID = -1, PaymentID = -1, CreatedByEmployeeID = -1;
            DateTime CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now;
            short NumberAdults = 1, NumberChildren = 1, BookingStatus = 0;
            float BookingAmount = 0, Discount = 0;

            if (clsBookingData.GetBookingInfoByID( BookingID, ref GuestID, ref PaymentID, ref BookingStatus, ref CheckInDate, ref CheckOutDate, ref NumberAdults, ref NumberChildren, ref BookingAmount, ref Discount, ref CreatedByEmployeeID))
            {
                return new clsBooking(BookingID, GuestID, PaymentID, (enBookingStatus)BookingStatus, CheckInDate, CheckOutDate, NumberAdults, NumberChildren, BookingAmount, Discount, CreatedByEmployeeID);

            }
            return null;

        }

        private bool _AddNewBooking()
        {
            this.BookingID = clsBookingData.AddNewBooking(GuestID, PaymentID,(short) BookingStatus, CheckInDate, CheckOutDate, NumberAdults, NumberChildren, BookingAmount, Discount, CreatedByEmployeeID);
            return (this.BookingID != -1);
        }

        private bool _UpdateBooking()
        {
            return clsBookingData.UpdateBooking(BookingID, GuestID, PaymentID, (short)BookingStatus, CheckInDate, CheckOutDate, NumberAdults, NumberChildren, BookingAmount, Discount, CreatedByEmployeeID);
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

        public static DataTable GetAllBookings()
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

        public static DataTable GetAllBookingsForPageNumber(int PageNumber)
        {
            return clsBookingData.GetAllBookingsForPageNumber(PageNumber);
        }

        public bool SetCancel()
        {
            return clsBookingData.SetCancelBooking(this.BookingID);
        }

        public static bool UpdateBookingStatusIfCompleted()
        {
            return clsBookingData.UpdateBookingStatusIfCompleted();
        }
    }
}
