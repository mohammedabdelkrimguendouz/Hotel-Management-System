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
        public int RoomClassBedTypeID { get; set; }
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        public int BedTypeID { get; set; }
        public clsBedType BedTypeInfo;
        public short BedsNumber { get; set; }

        private clsRoomClassBedType(int RoomClassBedTypeID, int RoomClassID, int BedTypeID, short BedsNumber)
        {
            this.RoomClassBedTypeID = RoomClassBedTypeID;
            this.RoomClassID = RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.BedTypeID = BedTypeID;
            this.BedTypeInfo = clsBedType.Find(BedTypeID);
            this.BedsNumber = BedsNumber;
            Mode = enMode.Update;
        }

        public clsRoomClassBedType()
        {
            RoomClassBedTypeID = -1;
            RoomClassID = -1;
            BedTypeID = -1;
            BedsNumber = 1;
            Mode = enMode.AddNew;
        }

        public static clsRoomClassBedType Find(int RoomClassBedTypeID)
        {

            int RoomClassID = -1, BedTypeID = -1; short BedsNumber = 0;

            if (clsRoomClassBedTypeData.GetRoomClassBedTypeInfoByID( RoomClassBedTypeID, ref RoomClassID, ref BedTypeID, ref BedsNumber))
            {
                return new clsRoomClassBedType(RoomClassBedTypeID, RoomClassID, BedTypeID, BedsNumber);

            }
            return null;

        }

        private bool _AddNewRoomClassBedType()
        {
            this.RoomClassBedTypeID = clsRoomClassBedTypeData.AddNewRoomClassBedType(RoomClassID, BedTypeID, BedsNumber);
            return (this.RoomClassBedTypeID != -1);
        }

        private bool _UpdateRoomClassBedType()
        {
            return clsRoomClassBedTypeData.UpdateRoomClassBedType(RoomClassBedTypeID, RoomClassID, BedTypeID, BedsNumber);
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

        public static DataTable GetAllRoomClassBedTypes()
        {
            return clsRoomClassBedTypeData.GetAllRoomClassBedTypes();
        }

        public static DataTable GetAllBedTypesForRoomClass(int RoomClassID)
        {
            return clsRoomClassBedTypeData.GetAllBedTypesForRoomClass(RoomClassID);
        }

        public static bool IsRoomClassBedTypeExistByBedTypeAndRoomClass(int RoomClassID,int BedTypeID)
        {
            return clsRoomClassBedTypeData.IsRoomClassBedTypeExistByBedTypeAndRoomClass(BedTypeID, RoomClassID);
        }
    }
}
