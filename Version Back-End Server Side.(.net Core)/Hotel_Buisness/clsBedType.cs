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

        public BedTypeDTO bedTypeDTO
        {
            get => new BedTypeDTO(this.BedTypeID, this.BedTypeName, this.Description);
        }
        public int BedTypeID { get; set; }
        public string BedTypeName { get; set; }
        public string Description { get; set; }


        public clsBedType(BedTypeDTO bedTypeDTO,enMode CreationMode=enMode.AddNew)
        {
            this.BedTypeID = bedTypeDTO.BedTypeID;
            this.BedTypeName = bedTypeDTO.BedTypeName;
            this.Description = bedTypeDTO.Description;
            Mode = CreationMode;
        }

       
        public static clsBedType Find(int BedTypeID)
        {
            BedTypeDTO bedTypeDTO = clsBedTypeData.GetBedTypeInfoByID(BedTypeID);


            if (bedTypeDTO!=null)
            {
                return new clsBedType(bedTypeDTO,enMode.Update);

            }
            return null;

        }
        public static clsBedType Find(string BedTypeName)
        {

            BedTypeDTO bedTypeDTO = clsBedTypeData.GetBedTypeInfoByName(BedTypeName);


            if (bedTypeDTO != null)
            {
                return new clsBedType(bedTypeDTO, enMode.Update);

            }
            return null;

        }

        private bool _AddNewBedType()
        {
            this.BedTypeID = clsBedTypeData.AddNewBedType(this.bedTypeDTO);
            return (this.BedTypeID != -1);
        }

        private bool _UpdateBedType()
        {
            return clsBedTypeData.UpdateBedType(this.bedTypeDTO);
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

        public static List<BedTypeDTO> GetAllBedTypes()
        {
            return clsBedTypeData.GetAllBedTypes();
        }

        public static bool IsBedTypeExist(string BedTypeName)
        {
            return clsBedTypeData.IsBedTypeExist(BedTypeName);
        }

    }
}
