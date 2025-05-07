using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsRoomClassBedType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public RoomClassBedTypeDTO roomClassBedTypeDTO
        {
            get => new RoomClassBedTypeDTO(this.RoomClassBedTypeID, this.RoomClassID, this.BedTypeID, this.BedsNumber);
        }
        public int RoomClassBedTypeID { get; set; }
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        public int BedTypeID { get; set; }
        public clsBedType BedTypeInfo;
        public short BedsNumber { get; set; }

        public clsRoomClassBedType(RoomClassBedTypeDTO roomClassBedTypeDTO,enMode CreationMode=enMode.AddNew)
        {
            this.RoomClassBedTypeID = roomClassBedTypeDTO.RoomClassBedTypeID;
            this.RoomClassID = roomClassBedTypeDTO.RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.BedTypeID = roomClassBedTypeDTO.BedTypeID;
            this.BedTypeInfo = clsBedType.Find(BedTypeID);
            this.BedsNumber = roomClassBedTypeDTO.BedsNumber;
            Mode = CreationMode;
        }

        public static clsRoomClassBedType Find(int RoomClassBedTypeID)
        {
            RoomClassBedTypeDTO roomClassBedTypeDTO = clsRoomClassBedTypeData.GetRoomClassBedTypeInfoByID(RoomClassBedTypeID);

            if (roomClassBedTypeDTO!=null)
            {
                return new clsRoomClassBedType(roomClassBedTypeDTO,enMode.Update);

            }
            return null;

        }

        private bool _AddNewRoomClassBedType()
        {
            this.RoomClassBedTypeID = clsRoomClassBedTypeData.AddNewRoomClassBedType(roomClassBedTypeDTO);
            return (this.RoomClassBedTypeID != -1);
        }

        private bool _UpdateRoomClassBedType()
        {
            return clsRoomClassBedTypeData.UpdateRoomClassBedType(roomClassBedTypeDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoomClassBedType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateRoomClassBedType();
            }
            return false;
        }

        public static bool DeleteRoomClassBedType(int RoomClassBedTypeID)
        {
            return clsRoomClassBedTypeData.DeleteRoomClassBedType(RoomClassBedTypeID);
        }

        public static List<RoomClassBedTypesListDTO> GetAllRoomClassBedTypes()
        {
            return clsRoomClassBedTypeData.GetAllRoomClassBedTypes();
        }

        public static List<BedTypesForRoomClassListDTO> GetAllBedTypesForRoomClass(int RoomClassID)
        {
            return clsRoomClassBedTypeData.GetAllBedTypesForRoomClass(RoomClassID);
        }

        public static bool IsRoomClassBedTypeExistByBedTypeAndRoomClass(int RoomClassID,int BedTypeID)
        {
            return clsRoomClassBedTypeData.IsRoomClassBedTypeExistByBedTypeAndRoomClass(BedTypeID, RoomClassID);
        }
    }
}
