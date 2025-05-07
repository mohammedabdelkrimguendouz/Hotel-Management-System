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
//using static DVLD_Buisness.clsGuest;

namespace Hotel.Guests
{
    public partial class ctrlGuestCardInfo : UserControl
    {
        private int _GuestID = -1;
        public int GuestID { get { return _GuestID; } }

        private clsGuest _Guest;
        public clsGuest SelectedGuestInfo { get { return _Guest; } }
        public ctrlGuestCardInfo()
        {
            InitializeComponent();
        }
        public void LoadGuestInfo(int GuestID)
        {
            _Guest = clsGuest.FindByGuestID(GuestID);
            if (_Guest == null)
            {
                ResetGuestInfo();
                MessageBox.Show("No Guest With ID = " + GuestID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillGuestInfo();

        }
        private void _FillGuestInfo()
        {
            _GuestID = _Guest.GuestID;
            llEditGuestInfo.Enabled = true;
            lblGuestID.Text = _Guest.GuestID.ToString();
            lblCreatedByEmplyoee.Text = _Guest.CreatedByEmployeeInfo.UserName.ToString();
            lblLoyaltyPoints.Text = _Guest.LoyaltyPoints.ToString();
            lblNumberOfBookings.Text = _Guest.NumberOfBookings.ToString();
            ctrlPersonCardInfo1.LoadPersonInfo(_Guest.PersonID);
        }
        public void LoadGuestInfo(string NationalNo)
        {
            _Guest = clsGuest.FindByNationalNo(NationalNo);
            if (_Guest == null)
            {
                ResetGuestInfo();
                MessageBox.Show("No Guest With National No = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillGuestInfo();
        }

        public void ResetGuestInfo()
        {
            ctrlPersonCardInfo1.ResetPersonInfo();
            lblCreatedByEmplyoee.Text= "[????]";
            lblGuestID.Text = "[????]";
            lblLoyaltyPoints.Text = "[????]";
            lblNumberOfBookings.Text= "[????]";
            llEditGuestInfo.Enabled = false;
            _GuestID = -1;
        }

        private void llEditGuestInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditGuest frm = new frmAddEditGuest(_GuestID);
            frm.ShowDialog();
            LoadGuestInfo(_GuestID);
        }
    }


}
