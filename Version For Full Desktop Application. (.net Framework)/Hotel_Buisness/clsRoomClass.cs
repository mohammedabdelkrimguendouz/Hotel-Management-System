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

        private clsRoomClass(int RoomClassID, string RoomClassName, float BasePrice)
        {
            this.RoomClassID = RoomClassID;
            this.RoomClassName = RoomClassName;
            this.BasePrice = BasePrice;
            Mode = enMode.Update;
        }

        public clsRoomClass()
        {
            RoomClassID = -1;
            RoomClassName = "";
            BasePrice = 0;
            Mode = enMode.AddNew;
        }

        public static clsRoomClass Find(int RoomClassID)
        {

            string RoomClassName = ""; float BasePrice = 0.0f;

            if (clsRoomClassData.GetRoomClassInfoByID( RoomClassID, ref RoomClassName, ref BasePrice))
            {
                return new clsRoomClass(RoomClassID, RoomClassName, BasePrice);

            }
            return null;

        }
        public static clsRoomClass Find(string RoomClassName)
        {

            int RoomClassID = -1; float BasePrice = 0.0f;

            if (clsRoomClassData.GetRoomClassInfoByName(RoomClassName,ref RoomClassID , ref BasePrice))
            {
                return new clsRoomClass(RoomClassID, RoomClassName, BasePrice);

            }
            return null;

        }

        private bool _AddNewRoomClass()
        {
            this.RoomClassID = clsRoomClassData.AddNewRoomClass(RoomClassName, BasePrice);
            return (this.RoomClassID != -1);

        }

        private bool _UpdateRoomClass()
        {
            return clsRoomClassData.UpdateRoomClass(RoomClassID, RoomClassName, BasePrice);
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

        public static DataTable GetAllRoomClasses()
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
