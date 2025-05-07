using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsRoomClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public RoomClassDTO roomClassDTO
        {
            get => new RoomClassDTO(this.RoomClassID, this.RoomClassName, this.BasePrice);
        }
        public int RoomClassID { get; set; }
        public string RoomClassName { get; set; }
        public float BasePrice { get; set; }

        public int NumberOfBedTypes
        {
            get
            {
                return clsRoomClassData.GetNumberOfBedTypes(RoomClassID);
            }
        }
        public int NumberOfFeatures
        {
            get
            {
                return clsRoomClassData.GetNumberOfFeatures(RoomClassID);
            }
        }

        public clsRoomClass(RoomClassDTO roomClassDTO,enMode CreationMode=enMode.AddNew)
        {
            this.RoomClassID = roomClassDTO.RoomClassID;
            this.RoomClassName = roomClassDTO.RoomClassName;
            this.BasePrice = roomClassDTO.BasePrice;
            Mode = CreationMode;
        }

     
        public static clsRoomClass Find(int RoomClassID)
        {

            RoomClassDTO roomClassDTO = clsRoomClassData.GetRoomClassInfoByID(RoomClassID);

            if (roomClassDTO!=null)
            {
                return new clsRoomClass(roomClassDTO,enMode.Update);

            }
            return null;

        }
        public static clsRoomClass Find(string RoomClassName)
        {

            RoomClassDTO roomClassDTO = clsRoomClassData.GetRoomClassInfoByName(RoomClassName);

            if (roomClassDTO != null)
            {
                return new clsRoomClass(roomClassDTO, enMode.Update);

            }
            return null;

        }

        private bool _AddNewRoomClass()
        {
            this.RoomClassID = clsRoomClassData.AddNewRoomClass(this.roomClassDTO);
            return (this.RoomClassID != -1);

        }

        private bool _UpdateRoomClass()
        {
            return clsRoomClassData.UpdateRoomClass(this.roomClassDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoomClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateRoomClass();
            }
            return false;
        }

        public static bool DeleteRoomClass(int RoomClassID)
        {
            return clsRoomClassData.DeleteRoomClass(RoomClassID);
        }

        public static List<RoomClassesListDTO> GetAllRoomClasses()
        {
            return clsRoomClassData.GetAllRoomClasses();
        }

        public static bool IsRoomClassExist(int RoomClassID)
        {
            return clsRoomClassData.IsRoomClassExistByID(RoomClassID);
        }
        public static bool IsRoomClassExist(string RoomClassName)
        {
            return clsRoomClassData.IsRoomClassExistByName(RoomClassName);
        }
    }
}
