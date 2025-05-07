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
        public int FloorID { get; set; }
        public short FloorNumber { get; set; }
        public float FloorArea { get; set; }

        private clsFloor(int FloorID, short FloorNumber, float FloorArea)
        {
            this.FloorID = FloorID;
            this.FloorNumber = FloorNumber;
            this.FloorArea = FloorArea;
            Mode = enMode.Update;
        }

        public clsFloor()
        {
            FloorID = -1;
            FloorNumber = 1;
            FloorArea = 0;
            Mode = enMode.AddNew;
        }

        public static clsFloor FindByID(int FloorID)
        {

            short FloorNumber = 1; float FloorArea = 0.0f;

            if (clsFloorData.GetFloorInfoByID( FloorID, ref FloorNumber, ref FloorArea))
            {
                return new clsFloor(FloorID, FloorNumber, FloorArea);

            }
            return null;

        }
        public static clsFloor FindByFloorNumber(short FloorNumber)
        {

            int FloorID = -1; float FloorArea = 0.0f;

            if (clsFloorData.GetFloorInfoByFloorNumber(FloorNumber,ref FloorID, ref FloorArea))
            {
                return new clsFloor(FloorID, FloorNumber, FloorArea);

            }
            return null;

        }

        private bool _AddNewFloor()
        {
            this.FloorID = clsFloorData.AddNewFloor(FloorNumber, FloorArea);
             return (this.FloorID != -1);

        }

        private bool _UpdateFloor()
        {
            return clsFloorData.UpdateFloor(FloorID, FloorNumber, FloorArea);
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

        public static DataTable GetAllFloors()
        {
            return clsFloorData.GetAllFloors();
        }

       

        public static bool IsNumberFloorExist(short FloorNumber)
        {
            return clsFloorData.IsNumberFloorExist(FloorNumber);
        }
    }
}
