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

        public BookingRoomDTO bookingRoomDTO
        {
            get => new BookingRoomDTO(this.BookingRoomID, this.BookingID, this.RoomID);
        }
        public int BookingRoomID { get; set; }
        public int BookingID { get; set; }
        public clsBooking BookingInfo;
        public int RoomID { get; set; }
        public clsRoom RoomInfo;

        public clsBookingRoom(BookingRoomDTO bookingRoomDTO,enMode CreationMode=enMode.AddNew)
        {
            this.BookingRoomID = bookingRoomDTO.BookingRoomID;
            this.BookingID = bookingRoomDTO.BookingID;
            this.BookingInfo=clsBooking.Find(BookingID);
            this.RoomID = bookingRoomDTO.RoomID;
            this.RoomInfo = clsRoom.FindByID(RoomID);
            Mode = CreationMode;
        }

        public static clsBookingRoom Find(int BookingRoomID)
        {

            BookingRoomDTO bookingRoomDTO = clsBookingRoomData.GetBookingRoomInfoByID(BookingRoomID);

            if (bookingRoomDTO!=null)
            {
                return new clsBookingRoom(bookingRoomDTO,enMode.Update);
            }
            return null;

        }

        private bool _AddNewBookingRoom()
        {
            this.BookingRoomID = clsBookingRoomData.AddNewBookingRoom(this.bookingRoomDTO);
            return (this.BookingRoomID != -1);
        }

        private bool _UpdateBookingRoom()
        {
            return clsBookingRoomData.UpdateBookingRoom(this.bookingRoomDTO);
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

        public static bool DeleteAllBookingRoomsForBookingID(int BookingID)
        {
            return clsBookingRoomData.DeleteAllBookingRoomsForBookingID(BookingID);
        }

        public static List<BookingRoomsListDTO> GetAllBookingRooms()
        {
            return clsBookingRoomData.GetAllBookingRooms();
        }
        

        public static List<RoomsForBookingsListDTO> GetAllRoomsForBookingID(int BookingID)
        {
            return clsBookingRoomData.GetAllRoomsForBookingID(BookingID);
        }

        public static bool IsBookingRoomExist(int BookingRoomID)
        {
            return clsBookingRoomData.IsBookingRoomExist(BookingRoomID);
        }
    }
}
