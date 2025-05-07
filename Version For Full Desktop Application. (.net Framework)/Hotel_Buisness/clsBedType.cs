using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsBedType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BedTypeID { get; set; }
        public string BedTypeName { get; set; }
        public string Description { get; set; }

        private clsBedType(int BedTypeID, string BedTypeName, string Description)
        {
            this.BedTypeID = BedTypeID;
            this.BedTypeName = BedTypeName;
            this.Description = Description;
            Mode = enMode.Update;
        }

        public clsBedType()
        {
            BedTypeID = -1;
            BedTypeName = "";
            Description = "";
            Mode = enMode.AddNew;
        }

        public static clsBedType Find(int BedTypeID)
        {

            string BedTypeName = "", Description = "";

            if (clsBedTypeData.GetBedTypeInfoByID( BedTypeID, ref BedTypeName, ref Description))
            {
                return new clsBedType(BedTypeID, BedTypeName, Description);

            }
            return null;

        }
        public static clsBedType Find(string BedTypeName)
        {

            int BedTypeID = -1;string Description = "";

            if (clsBedTypeData.GetBedTypeInfoByName(BedTypeName,ref BedTypeID, ref Description))
            {
                return new clsBedType(BedTypeID, BedTypeName, Description);

            }
            return null;

        }

        private bool _AddNewBedType()
        {
            this.BedTypeID = clsBedTypeData.AddNewBedType(BedTypeName, Description);
            return (this.BedTypeID != -1);
        }

        private bool _UpdateBedType()
        {
            return clsBedTypeData.UpdateBedType(BedTypeID, BedTypeName, Description);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBedType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateBedType();
            }
            return false;
        }

        public static bool DeleteBedType(int BedTypeID)
        {
            return clsBedTypeData.DeleteBedType(BedTypeID);
        }

        public static DataTable GetAllBedTypes()
        {
            return clsBedTypeData.GetAllBedTypes();
        }

        public static bool IsBedTypeExist(string BedTypeName)
        {
            return clsBedTypeData.IsBedTypeExist(BedTypeName);
        }

    }
}
