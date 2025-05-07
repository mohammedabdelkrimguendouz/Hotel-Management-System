using Guna.UI2.WinForms;
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

namespace Hotel.Bookings
{
    public partial class frmListBookings : Form
    {
        private static DataTable _dtAllBookings;
        private int _PageNumber = 1;

        private enum enAfterChangePage { AfterLoad = 0, AfterNext = 1, AfterPrev = 2, AfterAdd = 3 }
        private enAfterChangePage _AfterChangePage = enAfterChangePage.AfterLoad;
        public frmListBookings()
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
                    _ReferchListBookings();
                    btnNext.Enabled = (clsBooking.GetAllBookingsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterNext:
                    _PageNumber = _PageNumber + 1;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnPrev.Enabled = true;
                    _ReferchListBookings();
                    btnNext.Enabled = (clsBooking.GetAllBookingsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterPrev:
                    _PageNumber -= 1;
                    if (_PageNumber == 1)
                        btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnNext.Enabled = true;
                    _ReferchListBookings();
                    break;
                case enAfterChangePage.AfterAdd:
                    btnNext.Enabled = (clsBooking.GetAllBookingsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                
            }
        }

        private void _ReferchListBookings()
        {
            _dtAllBookings = clsBooking.GetAllBookingsForPageNumber(_PageNumber);
            dgvListBookings.DataSource = _dtAllBookings;
            lblRecordsCount.Text = dgvListBookings.Rows.Count.ToString();

           
            if (dgvListBookings.Rows.Count > 0)
            {
                dgvListBookings.Columns["BookingID"].HeaderText = "Booking ID";
                dgvListBookings.Columns["BookingID"].Width = 90;

                dgvListBookings.Columns["NationalNo"].HeaderText = "National No";
                dgvListBookings.Columns["NationalNo"].Width = 140;

                dgvListBookings.Columns["FullName"].HeaderText = "Full Name";
                dgvListBookings.Columns["FullName"].Width = 150;

                dgvListBookings.Columns["CheckInDate"].HeaderText = "Check In Date";
                dgvListBookings.Columns["CheckInDate"].Width = 130;

                dgvListBookings.Columns["CheckOutDate"].HeaderText = "Check Out Date";
                dgvListBookings.Columns["CheckOutDate"].Width = 130;

                dgvListBookings.Columns["PaymentAmount"].HeaderText = " Amount";
                dgvListBookings.Columns["PaymentAmount"].Width = 100;


                dgvListBookings.Columns["BookingStatus"].HeaderText = "Status";
                dgvListBookings.Columns["BookingStatus"].Width = 110;

                dgvListBookings.Columns["NumberOfRooms"].HeaderText = "Number Rooms";
                dgvListBookings.Columns["NumberOfRooms"].Width = 120;
            }
            cbFilter.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }

        private void frmListBookings_Load(object sender, EventArgs e)
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

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Number Rooms" || cbFilter.Text == "BookingID")

                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            

            cbBookingStatus.Visible = (cbFilter.Text == "Booking Status");

            txtfilterValue.Visible = (cbFilter.Text != "None" && !cbBookingStatus.Visible);
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }


            _dtAllBookings.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListBookings.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Booking ID":
                    FilterColumn = "BookingID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Number Rooms":
                    FilterColumn = "NumberOfRooms";
                    break;
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllBookings.DefaultView.RowFilter = "";
            else if (FilterColumn == "BookingID" || FilterColumn == "NumberOfRooms")
                _dtAllBookings.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            else
                _dtAllBookings.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListBookings.Rows.Count.ToString();
        }

        

        private void cbBookingStatus_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbBookingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterIColumn = "BookingStatus";
            string FilterValue = cbBookingStatus.Text.Trim();
            
            if (FilterValue == "All")
                _dtAllBookings.DefaultView.RowFilter = "";
            else
                _dtAllBookings.DefaultView.RowFilter = string.Format("[{0}]='{1}'", FilterIColumn, FilterValue);
            lblRecordsCount.Text = dgvListBookings.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditBooking frm = new frmAddEditBooking();
            frm.ShowDialog();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void addtoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddEditBooking frm = new frmAddEditBooking();
            frm.ShowDialog();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void edittoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int BookingID = (int)dgvListBookings.CurrentRow.Cells[0].Value;
            frmAddEditBooking frm = new frmAddEditBooking(BookingID);
            frm.ShowDialog();
            _ReferchListBookings();
        }

        private void showDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int BookingID = (int)dgvListBookings.CurrentRow.Cells[0].Value;
            frmShowBookingInfo frm = new frmShowBookingInfo(BookingID);
            frm.ShowDialog();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = (int)dgvListBookings.CurrentRow.Cells[0].Value;
            clsBooking Booking = clsBooking.Find(BookingID);
            if (Booking == null)
                return;

            if ((MessageBox.Show($"Are you sure to cancel this booking [{BookingID}] ", "Confirm",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.Cancel)
                return;


            if (!Booking.SetCancel())
            {
                MessageBox.Show(" Error to  Cancel  this Booking ", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Booking Cancel Succsseflly ", "Succsseflly",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            _ReferchListBookings();
            
               

        }

        private void cmsListBookings_Opening(object sender, CancelEventArgs e)
        {
            string BookingStatus = (string)dgvListBookings.CurrentRow.Cells[6].Value;

            edittoolStripMenuItem1.Enabled = (BookingStatus == "Pending");
            CancelToolStripMenuItem.Enabled= (BookingStatus == "Pending");
        }
    }
}
