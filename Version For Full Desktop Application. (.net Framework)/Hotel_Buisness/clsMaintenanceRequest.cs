using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsMaintenanceRequest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int MaintenanceRequestID { get; set; }
        public int RoomID { get; set; }

        public clsRoom RoomInfo;
        public DateTime MaintenanceRequestDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Description { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public clsEmployee CreatedByEmployeeInfo;

        private clsMaintenanceRequest(int MaintenanceRequestID, int RoomID, DateTime MaintenanceRequestDate, bool IsCompleted, DateTime? CompletedDate, string Description, int CreatedByEmployeeID)
        {
            this.MaintenanceRequestID = MaintenanceRequestID;
            this.RoomID = RoomID;
            this.RoomInfo = clsRoom.FindByID(RoomID);
            this.MaintenanceRequestDate = MaintenanceRequestDate;
            this.IsCompleted = IsCompleted;
            this.CompletedDate = CompletedDate;
            this.Description = Description;
            this.CreatedByEmployeeID = CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = enMode.Update;
        }

        public clsMaintenanceRequest()
        {
            MaintenanceRequestID = -1;
            RoomID = -1;
            MaintenanceRequestDate = DateTime.Now;
            IsCompleted = false;
            CompletedDate = null;
            Description = "";
            CreatedByEmployeeID = -1;
            Mode = enMode.AddNew;
        }

        public static clsMaintenanceRequest Find(int MaintenanceRequestID)
        {

            int RoomID = -1; DateTime MaintenanceRequestDate = DateTime.Now;  DateTime? CompletedDate = null;
            string Description = ""; int CreatedByEmployeeID = -1;bool IsCompleted = false;

            if (clsMaintenanceRequestData.GetMaintenanceRequestInfoByID( MaintenanceRequestID, ref RoomID, ref MaintenanceRequestDate, ref IsCompleted, ref CompletedDate, ref Description, ref CreatedByEmployeeID))
            {
                return new clsMaintenanceRequest(MaintenanceRequestID, RoomID, MaintenanceRequestDate, IsCompleted, CompletedDate, Description, CreatedByEmployeeID);

            }
            return null;

        }

        private bool _AddNewMaintenanceRequest()
        {
            this.MaintenanceRequestID = clsMaintenanceRequestData.AddNewMaintenanceRequest(RoomID, MaintenanceRequestDate, Description, CreatedByEmployeeID);
             return (this.MaintenanceRequestID != -1);
        }

        private bool _UpdateMaintenanceRequest()
        {
            return clsMaintenanceRequestData.UpdateMaintenanceRequest(MaintenanceRequestID, RoomID, MaintenanceRequestDate, Description, CreatedByEmployeeID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMaintenanceRequest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateMaintenanceRequest();
            }
            return false;
        }

        public bool SetCompleteMaintenance()
        {
            return clsMaintenanceRequestData.SetCompleteMaintenance(this.RoomID);
        }

        public static bool DeleteMaintenanceRequest(int MaintenanceRequestID)
        {
            return clsMaintenanceRequestData.DeleteMaintenanceRequest(MaintenanceRequestID);
        }

        public static DataTable GetAllMaintenanceRequests()
        {
            return clsMaintenanceRequestData.GetAllMaintenanceRequests();
        }
 
    }
}
