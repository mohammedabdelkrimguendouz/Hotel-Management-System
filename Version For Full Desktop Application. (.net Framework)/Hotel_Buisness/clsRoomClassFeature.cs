using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsRoomClassFeature
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int RoomClassFeatureID { get; set; }
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        public int FeatureID { get; set; }
        public clsFeature FeatureInfo;
        private clsRoomClassFeature(int RoomClassFeatureID, int RoomClassID, int FeatureID)
        {
            this.RoomClassFeatureID = RoomClassFeatureID;
            this.RoomClassID = RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.FeatureID = FeatureID;
            this.FeatureInfo = clsFeature.Find(FeatureID);
            Mode = enMode.Update;
        }

        public clsRoomClassFeature()
        {
            RoomClassFeatureID = -1;
            RoomClassID = -1;
            FeatureID = -1;
            Mode = enMode.AddNew;
        }

        public static clsRoomClassFeature Find(int RoomClassFeatureID)
        {

            int RoomClassID = -1, FeatureID = -1;

            if (clsRoomClassFeatureData.GetRoomClassFeatureInfoByID( RoomClassFeatureID, ref RoomClassID, ref FeatureID))
            {
                return new clsRoomClassFeature(RoomClassFeatureID, RoomClassID, FeatureID);

            }
            return null;

        }
        private bool _AddNewRoomClassFeature()
        {
            this.RoomClassFeatureID = clsRoomClassFeatureData.AddNewRoomClassFeature(RoomClassID, FeatureID);
           return (this.RoomClassFeatureID != -1);
        }

        private bool _UpdateRoomClassFeature()
        {
            return clsRoomClassFeatureData.UpdateRoomClassFeature(RoomClassFeatureID, RoomClassID, FeatureID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoomClassFeature())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateRoomClassFeature();
            }
            return false;
        }

        public static bool DeleteRoomClassFeature(int RoomClassFeatureID)
        {
            return clsRoomClassFeatureData.DeleteRoomClassFeature(RoomClassFeatureID);
        }

        public static DataTable GetAllRoomClassFeatures()
        {
            return clsRoomClassFeatureData.GetAllRoomClassFeatures();
        }

        public static bool IsRoomClassFeatureExistByFeatureAndRoomClass(int RoomClassID, int FeatureID)
        {
            return clsRoomClassFeatureData.IsRoomClassFeatureExistByFeatureAndRoomClass(FeatureID,RoomClassID);
        }

        public static DataTable GetAllFeaturesForRoomClass(int RoomClassID)
        {
            return clsRoomClassFeatureData.GetAllFeaturesForRoomClass(RoomClassID);
        }
    }
}
