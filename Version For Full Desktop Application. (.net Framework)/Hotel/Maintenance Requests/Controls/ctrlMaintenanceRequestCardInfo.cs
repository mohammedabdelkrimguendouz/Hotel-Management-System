using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Maintenance_Requests.Controls
{
    public partial class ctrlMaintenanceRequestCardInfo : UserControl
    {

        private int _MaintenanceRequestID = -1;
        public int MaintenanceRequestID { get { return _MaintenanceRequestID; } }

        private clsMaintenanceRequest _MaintenanceRequest;
        public clsMaintenanceRequest SelectedMaintenanceRequestInfo { get { return _MaintenanceRequest; } }
        public ctrlMaintenanceRequestCardInfo()
        {
            InitializeComponent();
        }

        public void LoadMaintenanceRequestInfo(int MaintenanceRequestID)
        {
            _MaintenanceRequest = clsMaintenanceRequest.Find(MaintenanceRequestID);
            if (_MaintenanceRequest == null)
            {
                ResetMaintenanceRequestInfo();
                MessageBox.Show("No Maintenance Request With ID = " + MaintenanceRequestID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMaintenanceRequestInfo();

        }
        private void _FillMaintenanceRequestInfo()
        {
            _MaintenanceRequestID = _MaintenanceRequest.MaintenanceRequestID;
            lblMaintenanceRequestID.Text = _MaintenanceRequest.MaintenanceRequestID.ToString();
            lblCreatedByEmployee.Text = _MaintenanceRequest.CreatedByEmployeeInfo.UserName;
            lblMaintenanceRequestDate.Text = clsFormat.DateToShort(_MaintenanceRequest.MaintenanceRequestDate);
            lblDescription.Text = _MaintenanceRequest.Description;
            lblCompletedDate.Text = (_MaintenanceRequest.CompletedDate != null) ? clsFormat.DateToShort(_MaintenanceRequest.CompletedDate.Value) : "Not Yet";
            lblIsCompleted.Text= (_MaintenanceRequest.CompletedDate != null)?"Yes":"No";
            ctrlRoomCardInfo1.LoadRoomInfoByID(_MaintenanceRequest.RoomID);
        }
        

        public void ResetMaintenanceRequestInfo()
        {
            ctrlRoomCardInfo1.ResetRoomInfo();
            lblCreatedByEmployee.Text = "[????]";
            lblMaintenanceRequestID.Text = "[????]";
            lblCompletedDate.Text = "[????]";
            lblIsCompleted.Text = "[????]";
            lblDescription.Text = "[????]";
            lblIsCompleted.Text= "[????]";
            _MaintenanceRequestID = -1;
        }
    }
}
