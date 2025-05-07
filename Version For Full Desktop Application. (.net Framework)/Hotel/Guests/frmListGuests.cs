using Hotel.Rooms;
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

namespace Hotel.Guests
{
    public partial class frmListGuests : Form
    {
        private static DataTable _dtAllGuests;
        private int _PageNumber = 1;

        private enum enAfterChangePage { AfterLoad = 0, AfterNext = 1, AfterPrev = 2, AfterAdd = 3, AfterDelete = 4 }
        private enAfterChangePage _AfterChangePage = enAfterChangePage.AfterLoad;

        public frmListGuests()
        {
            InitializeComponent();
        }

        private void _HandelPages()
        {
            switch (_AfterChangePage)
            {
                case enAfterChangePage.AfterLoad:
                    _PageNumber = 1;
                    btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    _ReferchListGuests();
                    btnNext.Enabled = (clsGuest.GetAllGuestsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterNext:
                    _PageNumber = _PageNumber + 1;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnPrev.Enabled = true;
                    _ReferchListGuests();
                    btnNext.Enabled = (clsGuest.GetAllGuestsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterPrev:
                    _PageNumber -= 1;
                    if (_PageNumber == 1)
                        btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnNext.Enabled = true;
                    _ReferchListGuests();
                    break;
                case enAfterChangePage.AfterAdd:
                    btnNext.Enabled = (clsGuest.GetAllGuestsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterDelete:
                    bool IsCurrentPageExist = (clsGuest.GetAllGuestsForPageNumber(_PageNumber).Rows.Count) > 0;
                    if (!IsCurrentPageExist)
                    {
                        btnNext.Enabled = false;

                        if (_PageNumber != 1)
                        {
                            _PageNumber -= 1;
                            lblPageNumber.Text = _PageNumber.ToString();
                            _ReferchListGuests();
                        }
                        else
                            btnPrev.Enabled = false;

                    }
                    else
                    {
                        bool IsNextPageExist = (clsGuest.GetAllGuestsForPageNumber(_PageNumber + 1)).Rows.Count > 0;

                        btnNext.Enabled = IsNextPageExist;
                        if (_PageNumber == 1)
                            btnPrev.Enabled = false;
                    }
                    break;
            }
        }

        private void _ReferchListGuests()
        {
            _dtAllGuests = clsGuest.GetAllGuestsForPageNumber(_PageNumber);
            dgvListGuests.DataSource = _dtAllGuests;
            lblRecordsCount.Text = dgvListGuests.Rows.Count.ToString();

            if (dgvListGuests.Rows.Count > 0)
            {
                dgvListGuests.Columns["GuestID"].HeaderText = "Guest ID";
                dgvListGuests.Columns["GuestID"].Width = 90;

                dgvListGuests.Columns["PersonID"].HeaderText = "Person ID";
                dgvListGuests.Columns["PersonID"].Width = 90;

                dgvListGuests.Columns["NationalNo"].HeaderText = "National No";
                dgvListGuests.Columns["NationalNo"].Width = 140;



                dgvListGuests.Columns["FullName"].HeaderText = "Full Name";
                dgvListGuests.Columns["FullName"].Width = 150;


                dgvListGuests.Columns["Phone"].HeaderText = "Phone";
                dgvListGuests.Columns["Phone"].Width = 100;


                dgvListGuests.Columns["NumberOfBookings"].HeaderText = "Number Of Bookings";
                //dgvListRooms.Columns["NumberOfBookings"].Width = 90;
            }
            cbFilter.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }

        private void frmListGuests_Load(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterLoad;
            _HandelPages();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterNext;
            _HandelPages();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterPrev;
            _HandelPages();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int GuestID = (int)dgvListGuests.CurrentRow.Cells[0].Value;
            frmShowGuestInfo frm = new frmShowGuestInfo(GuestID);
            frm.ShowDialog();
            _ReferchListGuests();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int GuestID = (int)dgvListGuests.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Guest [" + GuestID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            clsGuest _Guest = clsGuest.FindByGuestID(GuestID);
            if (_Guest == null)
                return;

            if (!_Guest.DeleteGuest())
            {
                MessageBox.Show("Guest Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Guest Deleted Successfully", "Successful", MessageBoxButtons.OK,
               MessageBoxIcon.Information);

            _ReferchListGuests();

            _AfterChangePage = enAfterChangePage.AfterDelete;
            _HandelPages();
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID"|| cbFilter.Text == "Guest ID" ||
                cbFilter.Text == "Number Of Bookings" )

                    e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilterValue.Visible = (cbFilter.Text != "None");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }

           
            _dtAllGuests.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListGuests.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Guest ID":
                    FilterColumn = "GuestID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Number Of Bookings":
                    FilterColumn = "NumberOfBookings";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllGuests.DefaultView.RowFilter = "";
            else if (FilterColumn == "PersonID" || FilterColumn == "GuestID"||
                FilterColumn == "NumberOfBookings")
                _dtAllGuests.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            else
                _dtAllGuests.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListGuests.Rows.Count.ToString();
        }

        private void addtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddEditGuest frm = new frmAddEditGuest();
            frm.ShowDialog();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditGuest frm = new frmAddEditGuest();
            frm.ShowDialog();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void edittoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int GuestID = (int)dgvListGuests.CurrentRow.Cells[0].Value;
            frmAddEditGuest frm = new frmAddEditGuest(GuestID);
            frm.ShowDialog();
        }
    }
}
