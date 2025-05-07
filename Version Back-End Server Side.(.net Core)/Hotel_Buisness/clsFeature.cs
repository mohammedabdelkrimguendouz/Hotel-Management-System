using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsFeature
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public FeatureDTO featureDTO
        {
            get => new FeatureDTO(this.FeatureID, this.FeatureName, this.Description);
        }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string Description { get; set; }

        public clsFeature(FeatureDTO featureDTO,enMode CreationMode=enMode.AddNew)
        {
            this.FeatureID = featureDTO.FeatureID;
            this.FeatureName = featureDTO.FeatureName;
            this.Description = featureDTO.Description;
            Mode = CreationMode;
        }

       
        public static clsFeature Find(int FeatureID)
        {

            FeatureDTO featureDTO = clsFeatureData.GetFeatureInfoByID(FeatureID);
            if (featureDTO!=null)
            {
                return new clsFeature(featureDTO,enMode.Update);

            }
            return null;

        }
        public static clsFeature Find(string FeatureName)
        {
            FeatureDTO featureDTO = clsFeatureData.GetFeatureInfoByName(FeatureName);
            if (featureDTO != null)
            {
                return new clsFeature(featureDTO, enMode.Update);

            }
            return null;

        }

        private bool _AddNewFeature()
        {
            this.FeatureID = clsFeatureData.AddNewFeature(this.featureDTO);
            return (this.FeatureID != -1);
        }

        private bool _UpdateFeature()
        {
            return clsFeatureData.UpdateFeature(this.featureDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFeature())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateFeature();
            }
            return false;
        }

        public static bool DeleteFeature(int FeatureID)
        {
            return clsFeatureData.DeleteFeature(FeatureID);
        }

        public static List<FeatureDTO> GetAllFeatures()
        {
            return clsFeatureData.GetAllFeatures();
        }

        public static bool IsFeatureExist(int FeatureID)
        {
            return clsFeatureData.IsFeatureExistByID(FeatureID);
        }
        public static bool IsFeatureExist(string FeatureName)
        {
            return clsFeatureData.IsFeatureExistByName(FeatureName);
        }
    }
}
