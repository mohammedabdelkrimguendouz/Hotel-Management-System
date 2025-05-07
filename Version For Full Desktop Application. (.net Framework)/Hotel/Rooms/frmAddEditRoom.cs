using DVLD.Global_Classes;
using DVLD_Buisness;
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

namespace Hotel.Rooms
{
    public partial class frmAddEditRoom : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _RoomID = -1;
        private clsRoom _Room;
        public frmAddEditRoom(int RoomID)
        {
            InitializeComponent();
            _RoomID = RoomID;
            _Mode = enMode.Update;
        }
        public frmAddEditRoom()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        private void _FillFloorNumbersInCompoBox()
        {
            DataTable dt = clsFloor.GetAllFloors();
            foreach (DataRow Row in dt.Rows)
            {
                cbFloorNumber.Items.Add(Row["FloorNumber"]);
            }
            if (cbFloorNumber.Items.Count >= 0)
                cbFloorNumber.SelectedIndex = 0;
        }
        private void _FillRoomClassesInCompoBox()
        {
            DataTable dt = clsRoomClass.GetAllRoomClasses();
            foreach (DataRow Row in dt.Rows)
            {
                cbRoomClass.Items.Add(Row["RoomClassName"]);
            }
            if (cbRoomClass.Items.Count >= 0)
                cbRoomClass.SelectedIndex = 0;
        }
       
        private void _ResetDefaultValues()
        {
            _FillFloorNumbersInCompoBox();
            _FillRoomClassesInCompoBox();
            
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Room";
                _Room = new clsRoom();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Room";
            }
            lblRoomID.Text = "[????]";
            chkAvailable.Checked = true;
            nudRoomNumber.Value = 1;
        }

        private void _LoadData()
        {
            _Room = clsRoom.FindByID(_RoomID);
            if (_Room == null)
            {
                MessageBox.Show("this form well be closed because No Room With ID : " + _RoomID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblRoomID.Text = _Room.RoomID.ToString();
            cbFloorNumber.SelectedIndex = cbFloorNumber.FindString(_Room.FloorInfo.FloorNumber.ToString());
            cbRoomClass.SelectedIndex = cbRoomClass.FindString(_Room.RoomClassInfo.RoomClassName);
            
            nudRoomNumber.Value = _Room.RoomNumber;
            chkAvailable.Checked = _Room.Available;
        }
        private void frmAddEditRoom_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Room.Available = chkAvailable.Checked;
           
            _Room.RoomNumber = (short)nudRoomNumber.Value;
            _Room.RoomClassID = clsRoomClass.Find(cbRoomClass.Text.Trim()).RoomClassID;
            _Room.FloorID = clsFloor.FindByFloorNumber(short.Parse(cbFloorNumber.Text.Trim())).FloorID;
            if (_Room.Save())
            {

                this.Text = lblTitle.Text = "Edit Room ";
                _Mode = enMode.Update;
                
                lblRoomID.Text = _Room.RoomID.ToString();
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nudRoomNumber_Validating(object sender, CancelEventArgs e)
        {
            if(clsRoom.IsRoomNumberExist((short)nudRoomNumber.Value))
            {
                e.Cancel = true;
                errorProvider1.SetError(nudRoomNumber, "This number used per anthore room !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nudRoomNumber, null);
            }
        }
    }
}
