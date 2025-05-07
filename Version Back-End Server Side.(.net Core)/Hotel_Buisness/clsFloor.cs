using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsFloor
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public FloorDTO floorDTO
        {
            get => new FloorDTO(this.FloorID, this.FloorNumber, this.FloorArea);
        }
        public int FloorID { get; set; }
        public byte FloorNumber { get; set; }
        public double FloorArea { get; set; }

        public clsFloor(FloorDTO floorDTO,enMode CreationMode=enMode.AddNew)
        {
            this.FloorID = floorDTO.FloorID;
            this.FloorNumber = floorDTO.FloorNumber;
            this.FloorArea = floorDTO.FloorArea;
            Mode = CreationMode;
        }

      
        public static clsFloor FindByID(int FloorID)
        {

            FloorDTO floorDTO = clsFloorData.GetFloorInfoByID(FloorID);

            if (floorDTO!=null)
            {
                return new clsFloor(floorDTO,enMode.Update);

            }
            return null;

        }
        public static clsFloor FindByFloorNumber(byte FloorNumber)
        {

            FloorDTO floorDTO = clsFloorData.GetFloorInfoByFloorNumber(FloorNumber);

            if (floorDTO != null)
            {
                return new clsFloor(floorDTO, enMode.Update);

            }
            return null;

        }

        private bool _AddNewFloor()
        {
            this.FloorID = clsFloorData.AddNewFloor(this.floorDTO);
             return (this.FloorID != -1);

        }

        private bool _UpdateFloor()
        {
            return clsFloorData.UpdateFloor(this.floorDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFloor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateFloor();
            }
            return false;
        }

        public static bool DeleteFloor(int FloorID)
        {
            return clsFloorData.DeleteFloor(FloorID);
        }

        public static List<FloorsListDTO> GetAllFloors()
        {
            return clsFloorData.GetAllFloors();
        }

        public static bool IsFloorNumberExist(byte FloorNumber)
        {
            return clsFloorData.IsFloorNumberExist(FloorNumber);
        }
    }
}
