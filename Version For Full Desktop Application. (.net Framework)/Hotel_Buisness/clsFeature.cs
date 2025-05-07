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
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string Description { get; set; }

        private clsFeature(int FeatureID, string FeatureName, string Description)
        {
            this.FeatureID = FeatureID;
            this.FeatureName = FeatureName;
            this.Description = Description;
            Mode = enMode.Update;
        }

        public clsFeature()
        {
            FeatureID = -1;
            FeatureName = "";
            Description = "";
            Mode = enMode.AddNew;
        }

        public static clsFeature Find(int FeatureID)
        {

            string FeatureName = "", Description = "";

            if (clsFeatureData.GetFeatureInfoByID( FeatureID, ref FeatureName, ref Description))
            {
                return new clsFeature(FeatureID, FeatureName, Description);

            }
            return null;

        }
        public static clsFeature Find(string FeatureName)
        {

            int FeatureID = -1; string Description = "";

            if (clsFeatureData.GetFeatureInfoByName(FeatureName ,ref FeatureID, ref Description))
            {
                return new clsFeature(FeatureID, FeatureName, Description);

            }
            return null;

        }

        private bool _AddNewFeature()
        {
            this.FeatureID = clsFeatureData.AddNewFeature(FeatureName, Description);
            return (this.FeatureID != -1);
        }

        private bool _UpdateFeature()
        {
            return clsFeatureData.UpdateFeature(FeatureID, FeatureName, Description);
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

        public static DataTable GetAllFeatures()
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
