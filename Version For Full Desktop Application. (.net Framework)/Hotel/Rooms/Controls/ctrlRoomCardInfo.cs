using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Hotel.Properties;
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

namespace Hotel.Rooms
{
    public partial class ctrlRoomCardInfo : UserControl
    {
        private int _RoomID = -1;
        public int RoomID { get { return _RoomID; } }

        private clsRoom _Room;
        public clsRoom SelectedRoomInfo { get { return _Room; } }
        public ctrlRoomCardInfo()
        {
            InitializeComponent();
        }
        public void LoadRoomInfoByID(int RoomID)
        {
            _Room = clsRoom.FindByID(RoomID);
            if (_Room == null)
            {
                ResetRoomInfo();
                MessageBox.Show("No Room With ID = " + RoomID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillRoomInfo();

        }

         public void LoadRoomInfoByRoomNumber(short RoomNumber)
         {
            _Room = clsRoom.FindByRoomNumber(RoomNumber);
            if (_Room == null)
            {
                ResetRoomInfo();
                MessageBox.Show("No Room With Number = " + RoomNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillRoomInfo();
         }
        private void _FillRoomInfo()
        {
            _RoomID = _Room.RoomID;
            lblRoomID.Text = _Room.RoomID.ToString();
            lblFloorArea.Text = _Room.FloorInfo.FloorArea.ToString();
            lblFloorNumber.Text = _Room.FloorInfo.FloorNumber.ToString();
            lblRoomClass.Text = _Room.RoomClassInfo.RoomClassName;
            lblPrice.Text = _Room.RoomClassInfo.BasePrice.ToString();
            lblRoomNumber.Text = _Room.RoomNumber.ToString();
            lblAvailable.Text = (_Room.Available) ? "Yes" : "No";
            lblNumberOfMaintenance.Text = _Room.NumberOfMaintenanceRequests.ToString();
            llEditRoomInfo.Enabled = true;
        }


        public void ResetRoomInfo()
        {
            lblRoomID.Text = "[????]";
            lblFloorArea.Text = "[????]";
            lblFloorNumber.Text = "[????]";
            lblRoomClass.Text = "[????]";
            lblPrice.Text = "[$$$$]";
            lblRoomNumber.Text = "[????]";
            lblAvailable.Text = "[????]";
            lblNumberOfMaintenance.Text= "[????]";
            llEditRoomInfo.Enabled = false;
            _RoomID = -1;
        }

        private void llEditRoomInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditRoom frm = new frmAddEditRoom(_RoomID);
            frm.ShowDialog();
            LoadRoomInfoByID(_RoomID);
        }
    }
}
