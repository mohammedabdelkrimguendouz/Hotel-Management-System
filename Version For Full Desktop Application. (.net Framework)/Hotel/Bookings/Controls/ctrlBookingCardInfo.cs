using Hotel.Guests;
using Hotel.Payments;
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

namespace Hotel.Bookings.Controls
{
    public partial class ctrlBookingCardInfo : UserControl
    {
        private static DataTable _dtAllRoomsForBooking;
        private int _BookingID = -1;
        public int BookingID { get { return _BookingID; } }

        private clsBooking _Booking;
        public clsBooking SelectedBookingInfo { get { return _Booking; } }
        public ctrlBookingCardInfo()
        {
            InitializeComponent();
        }

        public void LoadBookingnfo(int BookingID)
        {
            _Booking = clsBooking.Find(BookingID);
            if (_Booking == null)
            {
                ResetBookingnfo();
                MessageBox.Show("No Booking With ID = " + BookingID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillBookingInfo();

        }
        private void _FillBookingInfo()
        {
            _BookingID = _Booking.BookingID;
            llShowGuestInfo.Enabled = true;
            llShowPaymentInfo.Enabled = true;
            lblCreatedByEmployee.Text = _Booking.CreatedByEmployeeInfo.UserName;
            lblDiscount.Text = _Booking.Discount.ToString();
            lblBookingAmount.Text = _Booking.BookingAmount.ToString();
            lblNumberAdults.Text = _Booking.NumberAdults.ToString();
            lblNumberChildren.Text = _Booking.NumberChildren.ToString();
            lblCheckInDate.Text = _Booking.CheckInDate.ToString();
            lblCheckOutDate.Text = _Booking.CheckOutDate.ToString();
            lblBookingStatus.Text = _Booking.BookingStatus.ToString();
            lblBookingID.Text = _Booking.BookingID.ToString() ;
            _RefrechListRoomsForBooking();
        }
        private void _RefrechListRoomsForBooking()
        {
            _dtAllRoomsForBooking = clsBookingRoom.GetAllRoomsForBookingID(_Booking.BookingID);
            dgvListRoomsForBooking.DataSource = _dtAllRoomsForBooking;
            lblRecordsCount.Text = dgvListRoomsForBooking.Rows.Count.ToString();

            if (dgvListRoomsForBooking.Rows.Count > 0)
            {
                dgvListRoomsForBooking.Columns["RoomID"].HeaderText = "Room ID";
                //dgvListRoomsForBooking.Columns["RoomID"].Width = 90;

                dgvListRoomsForBooking.Columns["RoomClassName"].HeaderText = "Class Name";
                //dgvListRoomsForBooking.Columns["BasePrice"].Width = 140;

                dgvListRoomsForBooking.Columns["BasePrice"].HeaderText = "Price";
                //dgvListRoomsForBooking.Columns["BasePrice"].Width = 140;


                dgvListRoomsForBooking.Columns["FloorNumber"].HeaderText = "Floor Number";
                //dgvListRoomsForBooking.Columns["FloorNumber"].Width = 90;

                dgvListRoomsForBooking.Columns["RoomNumber"].HeaderText = "Room Number";
                //dgvListRoomsForBooking.Columns["RoomNumber"].Width = 100;


            }
        }

        public void ResetBookingnfo()
        {
            _BookingID = -1;
            llShowGuestInfo.Enabled = false;
            llShowPaymentInfo.Enabled = false;
            lblCreatedByEmployee.Text = "[????]";
            lblDiscount.Text = "[????]";
            lblBookingAmount.Text = "[????]";
            lblNumberAdults.Text = "[????]";
            lblNumberChildren.Text = "[????]";
            lblCheckInDate.Text = "[????]";
            lblCheckOutDate.Text = "[????]";
            lblBookingStatus.Text = "[????]";
            lblBookingID.Text = "[????]";
            _dtAllRoomsForBooking.Rows.Clear();
        }

        private void llShowGuestInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowGuestInfo frm = new frmShowGuestInfo(_Booking.GuestID);
            frm.ShowDialog();
        }

        private void llShowPaymentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPaymentInfo frm = new frmShowPaymentInfo(_Booking.PaymentID);
            frm.ShowDialog();
        }

        private void showRoomDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvListRoomsForBooking.CurrentRow.Cells[0].Value;
            frmShowRoomInfo frm = new frmShowRoomInfo(RoomID);
            frm.ShowDialog();
        }
    }
}
