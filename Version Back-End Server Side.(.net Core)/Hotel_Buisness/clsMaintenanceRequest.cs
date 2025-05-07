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

        public MaintenanceRequestDTO maintenanceRequestDTO
        {
            get => new MaintenanceRequestDTO(this.MaintenanceRequestID, this.RoomID, this.MaintenanceRequestDate,
                this.IsCompleted, this.CompletedDate, this.Description, this.CreatedByEmployeeID);
        }
        public int MaintenanceRequestID { get; set; }
        public int RoomID { get; set; }

        public clsRoom RoomInfo;
        public DateTime MaintenanceRequestDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Description { get; set; }
        public int CreatedByEmployeeID { get; set; }

        public clsEmployee CreatedByEmployeeInfo;

        public clsMaintenanceRequest(MaintenanceRequestDTO maintenanceRequestDTO,enMode CreationMode=enMode.AddNew)
        {
            this.MaintenanceRequestID = maintenanceRequestDTO.MaintenanceRequestID;
            this.RoomID = maintenanceRequestDTO.RoomID;
            this.RoomInfo = clsRoom.FindByID(RoomID);
            this.MaintenanceRequestDate = maintenanceRequestDTO.MaintenanceRequestDate;
            this.IsCompleted = maintenanceRequestDTO.IsCompleted;
            this.CompletedDate = maintenanceRequestDTO.CompletedDate;
            this.Description = maintenanceRequestDTO.Description;
            this.CreatedByEmployeeID = maintenanceRequestDTO.CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = CreationMode;
        }

       
        public static clsMaintenanceRequest Find(int MaintenanceRequestID)
        {

            MaintenanceRequestDTO maintenanceRequestDTO = clsMaintenanceRequestData.GetMaintenanceRequestInfoByID(MaintenanceRequestID);

            if (maintenanceRequestDTO!=null)
            {
                return new clsMaintenanceRequest(maintenanceRequestDTO,enMode.Update);

            }
            return null;

        }

        private bool _AddNewMaintenanceRequest()
        {
            this.MaintenanceRequestID = clsMaintenanceRequestData.AddNewMaintenanceRequest(maintenanceRequestDTO);
             return (this.MaintenanceRequestID != -1);
        }

        private bool _UpdateMaintenanceRequest()
        {
            return clsMaintenanceRequestData.UpdateMaintenanceRequest(maintenanceRequestDTO);
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

        public static List<MaintenanceRequestsListDTO> GetAllMaintenanceRequests()
        {
            return clsMaintenanceRequestData.GetAllMaintenanceRequests();
        }
 
    }
}
