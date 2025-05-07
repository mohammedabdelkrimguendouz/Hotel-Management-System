using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsBookingRoom
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BookingRoomID { get; set; }
        public int BookingID { get; set; }
        public clsBooking BookingInfo;
        public int RoomID { get; set; }
        public clsRoom RoomInfo;

        private clsBookingRoom(int BookingRoomID, int BookingID, int RoomID)
        {
            this.BookingRoomID = BookingRoomID;
            this.BookingID = BookingID;
            this.BookingInfo=clsBooking.Find(BookingID);
            this.RoomID = RoomID;
            this.RoomInfo = clsRoom.FindByID(RoomID);
            Mode = enMode.Update;
        }

        public clsBookingRoom()
        {
            BookingRoomID = -1;
            BookingID = -1;
            RoomID = -1;
            Mode = enMode.AddNew;
        }

        public static clsBookingRoom Find(int BookingRoomID)
        {

            int BookingID = -1, RoomID = -1;

            if (clsBookingRoomData.GetBookingRoomInfoByID( BookingRoomID, ref BookingID, ref RoomID))
            {
                return new clsBookingRoom(BookingRoomID, BookingID, RoomID);
            }
            return null;

        }

        private bool _AddNewBookingRoom()
        {
            this.BookingRoomID = clsBookingRoomData.AddNewBookingRoom(BookingID, RoomID);
            return (this.BookingRoomID != -1);
        }

        private bool _UpdateBookingRoom()
        {
            return clsBookingRoomData.UpdateBookingRoom(BookingRoomID, BookingID, RoomID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBookingRoom())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateBookingRoom();
            }
            return false;
        }

        public static bool DeleteBookingRoom(int BookingRoomID)
        {
            return clsBookingRoomData.DeleteBookingRoom(BookingRoomID);
        }

        public static bool DeleteAllBookingRoomForBookingID(int BookingID)
        {
            return clsBookingRoomData.DeleteAllBookingRoomForBookingID(BookingID);
        }

        public static DataTable GetAllBookingRooms()
        {
            return clsBookingRoomData.GetAllBookingRooms();
        }
        

        public static DataTable GetAllRoomsForBookingID(int BookingID)
        {
            return clsBookingRoomData.GetAllRoomsForBookingID(BookingID);
        }

        public static bool IsBookingRoomExist(int BookingRoomID)
        {
            return clsBookingRoomData.IsBookingRoomExist(BookingRoomID);
        }
    }
}
