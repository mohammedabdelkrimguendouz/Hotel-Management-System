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

        public RoomClassFeatureDTO roomClassFeatureDTO
        {
            get => new RoomClassFeatureDTO(this.RoomClassFeatureID, this.RoomClassID, this.FeatureID);
        }
        public int RoomClassFeatureID { get; set; }
        public int RoomClassID { get; set; }
        public clsRoomClass RoomClassInfo;
        public int FeatureID { get; set; }
        public clsFeature FeatureInfo;
        public clsRoomClassFeature(RoomClassFeatureDTO roomClassFeatureDTO,enMode CreationMode=enMode.AddNew)
        {
            this.RoomClassFeatureID = roomClassFeatureDTO.RoomClassFeatureID;
            this.RoomClassID = roomClassFeatureDTO.RoomClassID;
            this.RoomClassInfo = clsRoomClass.Find(RoomClassID);
            this.FeatureID = roomClassFeatureDTO.FeatureID;
            this.FeatureInfo = clsFeature.Find(FeatureID);
            Mode = enMode.Update;
        }

        public static clsRoomClassFeature Find(int RoomClassFeatureID)
        {

            RoomClassFeatureDTO roomClassFeatureDTO = clsRoomClassFeatureData.GetRoomClassFeatureInfoByID(RoomClassFeatureID);

            if (roomClassFeatureDTO!=null)
            {
                return new clsRoomClassFeature(roomClassFeatureDTO,enMode.Update);

            }
            return null;

        }
        private bool _AddNewRoomClassFeature()
        {
            this.RoomClassFeatureID = clsRoomClassFeatureData.AddNewRoomClassFeature(this.roomClassFeatureDTO);
           return (this.RoomClassFeatureID != -1);
        }

        private bool _UpdateRoomClassFeature()
        {
            return clsRoomClassFeatureData.UpdateRoomClassFeature(roomClassFeatureDTO);
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

        public static List<RoomClassFeaturesListDTO> GetAllRoomClassFeatures()
        {
            return clsRoomClassFeatureData.GetAllRoomClassFeatures();
        }

        public static bool IsRoomClassFeatureExistByFeatureAndRoomClass(int RoomClassID, int FeatureID)
        {
            return clsRoomClassFeatureData.IsRoomClassFeatureExistByFeatureAndRoomClass(FeatureID,RoomClassID);
        }

        public static List<FeaturesForRoomClassListDTO> GetAllFeaturesForRoomClass(int RoomClassID)
        {
            return clsRoomClassFeatureData.GetAllFeaturesForRoomClass(RoomClassID);
        }
    }
}
