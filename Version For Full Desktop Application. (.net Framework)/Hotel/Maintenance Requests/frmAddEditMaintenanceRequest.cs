using DVLD.Global_Classes;
using DVLD_Buisness;
using Guna.UI2.WinForms.Suite;
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
using TheArtOfDevHtmlRenderer.Adapters;

namespace Hotel.Maintenance_Requests
{
    public partial class frmAddEditMaintenanceRequest : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _MaintenanceRequestID = -1;
        private clsMaintenanceRequest _MaintenanceRequest;

        public frmAddEditMaintenanceRequest()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditMaintenanceRequest(int MaintenanceRequestID)
        {
            InitializeComponent();
            _MaintenanceRequestID = MaintenanceRequestID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Maintenance Request";
                _MaintenanceRequest = new clsMaintenanceRequest();
                

            }
            else
            {
                this.Text = lblTitle.Text = "Edit Maintenance Request";
                ctrlRoomCardInfoWithFilter1.EnableFilter = false;
            }
            lblCreatedByEmployee.Text = clsGlobal.CurrentEmployee.UserName;
            lblMaintenanceRequestID.Text = "[????]";
            txtDescription.Text = "";
            dtpMaintenanceRequestDate.Value = DateTime.Now;
            btnMaintenance.Enabled = false;
        }

        private void _LoadData()
        {
            _MaintenanceRequest = clsMaintenanceRequest.Find(_MaintenanceRequestID);
            if (_MaintenanceRequest == null)
            {
                MessageBox.Show("this form well be closed because No Maintenance Request With ID : " + _MaintenanceRequestID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            lblMaintenanceRequestID.Text = _MaintenanceRequest.MaintenanceRequestID.ToString();
            txtDescription.Text = _MaintenanceRequest.Description;
            lblCreatedByEmployee.Text = _MaintenanceRequest.CreatedByEmployeeInfo.UserName ;
            dtpMaintenanceRequestDate.Value = _MaintenanceRequest.MaintenanceRequestDate;
            ctrlRoomCardInfoWithFilter1.EnableFilter = false;
            ctrlRoomCardInfoWithFilter1.LoadRoomInfoByRoomID(_MaintenanceRequest.RoomID);
            btnMaintenance.Enabled =! _MaintenanceRequest.IsCompleted;
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {

            _MaintenanceRequest.CreatedByEmployeeID = clsGlobal.CurrentEmployee.EmployeeID;
            _MaintenanceRequest.Description = txtDescription.Text.Trim();
            _MaintenanceRequest.MaintenanceRequestDate = dtpMaintenanceRequestDate.Value;
            _MaintenanceRequest.RoomID = ctrlRoomCardInfoWithFilter1.RoomID;

            if (_MaintenanceRequest.Save())
            {

                this.Text = lblTitle.Text = "Edit Maintenance Request ";
                _Mode = enMode.Update;
                lblMaintenanceRequestID.Text = _MaintenanceRequest.MaintenanceRequestID.ToString();
               
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditMaintenanceRequest_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void ctrlRoomCardInfoWithFilter1_OnRoomSelected(object sender, Rooms.Controls.ctrlRoomCardInfoWithFilter.RoomSelectedEventArgs e)
        {
            int RoomID = e.RoomID;

            if (RoomID == -1)
            {
                btnMaintenance.Enabled = false;
                return;
            }
               

            if(!ctrlRoomCardInfoWithFilter1.SelectedRoomInfo.Available)
            {
                MessageBox.Show("this room is not available", "Not Access", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            btnMaintenance.Enabled = true;

        }
    }
}
