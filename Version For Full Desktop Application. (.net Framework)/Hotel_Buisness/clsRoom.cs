using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsRoom
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int RoomID { get; set; }
        public int FloorID { get; set; }

        public clsFloor FloorInfo;
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        
        public int NumberOfMaintenanceRequests
        {
            get
            {
                return clsRoomData.GetNumberOfMaintenanceRequests(this.RoomID);
            }
        }
        public short RoomNumber { get; set; }
        public bool Available { get; set; }

    

        private clsRoom(int RoomID, int FloorID, int RoomClassID, short RoomNumber, bool Available)
        {
            this.RoomID = RoomID;
            this.FloorID = FloorID;
            this.FloorInfo = clsFloor.FindByID(FloorID);
            this.RoomClassID = RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.RoomNumber = RoomNumber;
            this.Available = Available;
            Mode = enMode.Update;
        }

        public clsRoom()
        {
            RoomID = -1;
            FloorID = -1;
            RoomClassID = -1;
            RoomNumber = 1;
            Available = false;
            Mode = enMode.AddNew;
        }

        public static clsRoom FindByID(int RoomID)
        {

            int FloorID = -1, RoomClassID = -1; short RoomNumber = 1; bool Available = false;

            if (clsRoomData.GetRoomInfoByID(RoomID, ref FloorID, ref RoomClassID, ref RoomNumber, ref Available))
            {

                return new clsRoom(RoomID, FloorID, RoomClassID, RoomNumber, Available);

            }
            return null;

        }
        public static clsRoom FindByRoomNumber(short RoomNumber)
        {

            int FloorID = -1, RoomClassID = -1; int RoomID = -1; bool Available = false;

            if (clsRoomData.GetRoomInfoByRoomNumber(RoomNumber,ref RoomID, ref FloorID, ref RoomClassID, ref Available))
            {

                return new clsRoom(RoomID, FloorID, RoomClassID, RoomNumber, Available);

            }
            return null;

        }

        private bool _AddNewRoom()
        {
            this.RoomID = clsRoomData.AddNewRoom(FloorID, RoomClassID, RoomNumber, Available);
            return (this.RoomID != -1);
        }

        private bool _UpdateRoom()
        {
            return clsRoomData.UpdateRoom(RoomID, FloorID, RoomClassID, RoomNumber, Available);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoom())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateRoom();
            }
            return false;
        }

        public static bool DeleteRoom(int RoomID)
        {
            return clsRoomData.DeleteRoom(RoomID);
        }

        public static DataTable GetAllRooms()
        {
            return clsRoomData.GetAllRooms();
        }
        public static DataTable GetAllRoomsForRoomClass(int RoomClassID)
        {
            return clsRoomData.GetAllRoomsForRoomClass(RoomClassID);
        }

        public static DataTable GetRoom(int RoomID)
        {
            return clsRoomData.GetRoom(RoomID);
        }


        public static DataTable GetAllRoomsForPageNumber(int PageNumber)
        {
            return clsRoomData.GetAllRoomsForPageNumber(PageNumber);
        }

        


        public static bool IsRoomExist(int RoomID)
        {
            return clsRoomData.IsRoomExist(RoomID);
        }
        public static bool IsRoomNumberExist(short RoomNumber)
        {
            return clsRoomData.IsRoomNumberExist(RoomNumber);
        }

        public bool UpdateStatus(bool NewStatus)
        {
            return clsRoomData.UpdateRoomStatus(this.RoomID, NewStatus);
        }
        

    }
}
