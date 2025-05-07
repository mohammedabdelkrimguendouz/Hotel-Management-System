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

        public RoomDTO roomDTO
        {
            get => new RoomDTO(this.RoomID, this.FloorID, this.RoomClassID, this.RoomNumber, this.Available);
        }
        public int RoomID { get; set; }
        public int FloorID { get; set; }

        public clsFloor FloorInfo;
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        
        
        public int RoomNumber { get; set; }
        public bool Available { get; set; }

        public int NumberOfMaintenanceRequests
        {
            get
            {
                return clsRoomData.GetNumberOfMaintenanceRequests(this.RoomID);
            }
        }

        public clsRoom(RoomDTO roomDTO,enMode CreationMode=enMode.AddNew)
        {
            this.RoomID = roomDTO.RoomID;
            this.FloorID = roomDTO.FloorID;
            this.FloorInfo = clsFloor.FindByID(FloorID);
            this.RoomClassID = roomDTO.RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.RoomNumber = roomDTO.RoomNumber;
            this.Available = roomDTO.Available;
            Mode = CreationMode;
        }

      
        public static clsRoom FindByID(int RoomID)
        {

            RoomDTO roomDTO = clsRoomData.GetRoomInfoByID(RoomID);

            if (roomDTO!=null)
            {

                return new clsRoom(roomDTO,enMode.Update);

            }
            return null;

        }
        public static clsRoom FindByRoomNumber(int RoomNumber)
        {

            RoomDTO roomDTO = clsRoomData.GetRoomInfoByRoomNumber(RoomNumber);

            if (roomDTO != null)
            {

                return new clsRoom(roomDTO, enMode.Update);

            }
            return null;


        }

        private bool _AddNewRoom()
        {
            this.RoomID = clsRoomData.AddNewRoom(this.roomDTO);
            return (this.RoomID != -1);
        }

        private bool _UpdateRoom()
        {
            return clsRoomData.UpdateRoom(this.roomDTO);
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

        public static List<RoomsListDTO> GetAllRooms()
        {
            return clsRoomData.GetAllRooms();
        }
        public static List<RoomsListDTO> GetAllRoomsForRoomClass(int RoomClassID)
        {
            return clsRoomData.GetAllRoomsForRoomClass(RoomClassID);
        }

        public static List<RoomsListDTO> GetRoom(int RoomID)
        {
            return clsRoomData.GetRoom(RoomID);
        }


        public static List<RoomsListDTO> GetAllRoomsForPageNumber(int PageNumber)
        {
            return clsRoomData.GetAllRoomsForPageNumber(PageNumber);
        }

        


        public static bool IsRoomExist(int RoomID)
        {
            return clsRoomData.IsRoomExist(RoomID);
        }
        public static bool IsRoomNumberExist(int RoomNumber)
        {
            return clsRoomData.IsRoomNumberExist(RoomNumber);
        }

        public bool UpdateStatus(bool NewStatus)
        {
            return clsRoomData.UpdateRoomStatus(this.RoomID, NewStatus);
        }
        

    }
}
