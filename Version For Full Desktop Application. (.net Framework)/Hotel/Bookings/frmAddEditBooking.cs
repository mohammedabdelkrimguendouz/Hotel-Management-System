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

namespace Hotel.Bookings
{
    public partial class frmAddEditBooking : Form
    {
        private static DataTable _dtAllRoomsForRoomClass;
        private static DataTable _dtRoomForBooking;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _BookingID = -1;
        private clsBooking _Booking;
        private clsPayment _Payment;
        private clsBookingRoom _BookingRoom;
        public frmAddEditBooking(int BookingID)
        {
            InitializeComponent();
            _BookingID = BookingID;
            _Mode = enMode.Update;
        }
        public frmAddEditBooking()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillRoomClassesInCompoBox()
        {
            DataTable dt = clsRoomClass.GetAllRoomClasses();
            foreach (DataRow Row in dt.Rows)
            {
                cbRoomClasses.Items.Add(Row["RoomClassName"]);
            }
                cbRoomClasses.SelectedIndex = 0;
        }
        private void _ResetDefaultValues()
        {
            _FillRoomClassesInCompoBox();
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Booking";
                btnSave.Enabled = false;
                pPaymentInfo.Enabled = false;
                pBookingInfo.Enabled = false;
                ctrlGuestInfoWithFilter1.FilterFocus();
                _Booking = new clsBooking();
                _Payment = new clsPayment();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Booking";
            }
            lblBookingID.Text = "[????]";
            nudNumberAdults.Value = 1;
            nudNumberChildren.Value = 0;
            lblBookingAmount.Text = clsSetting.GetFoodPrice().ToString();
            lblDiscount.Text = "0";
            lblCheckInDate.Text = DateTime.Now.ToString();
            dtpCheckOutDate.MinDate = DateTime.Now.AddDays(1);
            dtpCheckOutDate.Value = dtpCheckOutDate.MinDate;

            lblPaymentID.Text = "[????]";
            lblPaymentDate.Text = DateTime.Now.ToString();
            lblPaymentAmount.Text = "0";
            txtNotes.Text = "";
            rbCash.Checked = true;

            cbRoomClasses.SelectedIndex = 0;

        }

        private int _GetRoomClassID()
        {
            if (cbRoomClasses.Text == "None")
                return -1;
            return clsRoomClass.Find(cbRoomClasses.Text).RoomClassID;
        }
        private void _ReferchListRoomsForRoomClass()
        {
            _dtAllRoomsForRoomClass = clsRoom.GetAllRoomsForRoomClass(_GetRoomClassID());
            dgvListRoomsForRoomClass.DataSource = _dtAllRoomsForRoomClass;
            lblRecordsCountForRooms.Text = dgvListRoomsForRoomClass.Rows.Count.ToString();

            if (dgvListRoomsForRoomClass.Rows.Count > 0)
            {
                dgvListRoomsForRoomClass.Columns["RoomID"].HeaderText = "Room ID";
                //dgvListRoomsForRoomClass.Columns["RoomID"].Width = 90;

                

                dgvListRoomsForRoomClass.Columns["BasePrice"].HeaderText = "Price";
                //dgvListRoomsForRoomClass.Columns["BasePrice"].Width = 140;


                dgvListRoomsForRoomClass.Columns["FloorNumber"].HeaderText = "Floor Number";
                //dgvListRoomsForRoomClass.Columns["FloorNumber"].Width = 90;

                dgvListRoomsForRoomClass.Columns["RoomNumber"].HeaderText = "Room Number";
                //dgvListRoomsForRoomClass.Columns["RoomNumber"].Width = 100;

                
            }
           
        }

        private float _GetBookingAmount(float RoomPrice)
        {
            int LoyaltyPoints = ctrlGuestInfoWithFilter1.SelectedGuestInfo.LoyaltyPoints;
            return (Convert.ToSingle(lblBookingAmount.Text) + RoomPrice);
        }
        private void _ReferchListRoomsForBooking(int BookingID)
        {
            _dtRoomForBooking = clsBookingRoom.GetAllRoomsForBookingID(BookingID);

            foreach (DataRow row in _dtRoomForBooking.Rows)
                dgvListRoomsForBooking.Rows.Add(row["RoomID"], row["RoomClassName"], row["BasePrice"],
                    row["FloorNumber"], row["RoomNumber"]);
            lblRecordsCountForRoomsBooking.Text = dgvListRoomsForBooking.Rows.Count.ToString();

           

        }
        private void _AddRoomToBookingsList(int RoomIdToAdd)
        {
            _dtRoomForBooking= clsRoom.GetRoom(RoomIdToAdd);

            foreach (DataRow row in _dtRoomForBooking.Rows)
                dgvListRoomsForBooking.Rows.Add(row["RoomID"], row["RoomClassName"], row["BasePrice"],
                    row["FloorNumber"], row["RoomNumber"]);


            lblRecordsCountForRoomsBooking.Text = dgvListRoomsForBooking.Rows.Count.ToString();
            

        }
        
        private void _LoadData()
        {
            _Booking = clsBooking.Find(_BookingID);
            if (_Booking == null)
            {
                MessageBox.Show("this form well be closed because No Booking With ID : " + _BookingID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlGuestInfoWithFilter1.EnableFilter = false;
            ctrlGuestInfoWithFilter1.LoadGuestInfo(_Booking.GuestInfo.NationalNo);
            lblBookingID.Text = _Booking.BookingID.ToString();
            nudNumberAdults.Value = _Booking.NumberAdults;
            nudNumberChildren.Value = _Booking.NumberChildren;
            lblBookingAmount.Text = _Booking.BookingAmount.ToString();
            lblDiscount.Text = _Booking.Discount.ToString();
            lblCheckInDate.Text = _Booking.CheckInDate.ToString();
            dtpCheckOutDate.MinDate = _Booking.CheckInDate.AddDays(1);
            dtpCheckOutDate.Value = _Booking.CheckOutDate;
            if (DateTime.Now > _Booking.CheckOutDate)
                dtpCheckOutDate.Enabled = false;


            _Payment = clsPayment.Find(_Booking.PaymentID);
            lblPaymentID.Text = _Booking.PaymentID.ToString();
            lblPaymentDate.Text = _Booking.PaymentInfo.PaymentDate.ToString();
            lblPaymentAmount.Text = _Booking.PaymentInfo.PaymentAmount.ToString();
            txtNotes.Text = _Booking.PaymentInfo.Notes;
            rbCash.Checked = (clsPayment.enPaymentMethod.Cash==_Booking.PaymentInfo.PaymentMethod)?true:rbCreditCard.Checked=true;
            _ReferchListRoomsForBooking(_Booking.BookingID);

        }
        private void frmAddEditBooking_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNextToBookingInfo_Click(object sender, EventArgs e)
        {
            
            if(ctrlGuestInfoWithFilter1.GuestID ==-1)
            {
                MessageBox.Show("Please Select Or Add Guest ! ", "Not Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mode==enMode.AddNew&& clsBooking.DeosExistBookingActiveForGuest(ctrlGuestInfoWithFilter1.GuestID))
            {
                MessageBox.Show("is exist Booking pending for this guest ! ", "Not Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pBookingInfo.Enabled = true;
            tcBooking.SelectedTab = tcBooking.TabPages["tpBookingInfo"];

           
        }

        private void btnBackToGuestInfo_Click(object sender, EventArgs e)
        {
            tcBooking.SelectedTab = tcBooking.TabPages["tpGuestInfo"];
        }

        private void btnNextToPaymentInfo_Click(object sender, EventArgs e)
        {
            if (dgvListRoomsForBooking.Rows.Count == 0)
            {
                MessageBox.Show("Please Select Room  ! ", "Not Access",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pPaymentInfo.Enabled = true;
            btnSave.Enabled = true;
            tcBooking.SelectedTab = tcBooking.TabPages["tpPaymentInfo"];
            lblPaymentAmount.Text = (Convert.ToSingle(lblBookingAmount.Text) - Convert.ToSingle(lblDiscount.Text)).ToString();



        }

        private void btnBackToBookingInfo_Click(object sender, EventArgs e)
        {
            tcBooking.SelectedTab = tcBooking.TabPages["tpBookingInfo"];
        }

        private void cbRoomClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvListRoomsForRoomClass.Rows.Count > 0)
            {
                _dtAllRoomsForRoomClass.Rows.Clear();
                if (cbRoomClasses.Text == "None")
                    return;
            }

            _ReferchListRoomsForRoomClass();
            btnChoose.Enabled = _dtAllRoomsForRoomClass.Rows.Count > 0;
        }

        private void _UpdateRoomStaus(int RoomID,bool NewStatus)
        {
            clsRoom Room = clsRoom.FindByID(RoomID);
            if (Room == null)
                return;
            Room.UpdateStatus(NewStatus);

            _ReferchListRoomsForRoomClass();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvListRoomsForRoomClass.CurrentRow.Cells[0].Value;
            float RoomPrice=Convert.ToSingle(dgvListRoomsForRoomClass.CurrentRow.Cells[1].Value);
            lblBookingAmount.Text = _GetBookingAmount(RoomPrice).ToString();
            lblDiscount.Text = clsBooking.CalculateDiscount(ctrlGuestInfoWithFilter1.SelectedGuestInfo
                .LoyaltyPoints, Convert.ToSingle(lblBookingAmount.Text)).ToString();
            _UpdateRoomStaus(RoomID, false);
            _AddRoomToBookingsList(RoomID);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListRoomsForBooking.CurrentRow == null)
                return;

            int IndexRow = (int)dgvListRoomsForBooking.CurrentRow.Index;
            int RoomID= (int)dgvListRoomsForBooking.CurrentRow.Cells[0].Value;
            float RoomPrice = Convert.ToSingle(dgvListRoomsForBooking.CurrentRow.Cells[2].Value);
            lblBookingAmount.Text = _GetBookingAmount(RoomPrice*-1).ToString();
            lblDiscount.Text = clsBooking.CalculateDiscount(ctrlGuestInfoWithFilter1.SelectedGuestInfo
                .LoyaltyPoints, Convert.ToSingle(lblBookingAmount.Text)).ToString();
            _UpdateRoomStaus(RoomID, true);
            dgvListRoomsForBooking.Rows.RemoveAt(IndexRow);
            lblRecordsCountForRoomsBooking.Text = dgvListRoomsForBooking.Rows.Count.ToString();

        }


       
        private void SaveBookingRooms()
        {
            if (_Mode == enMode.Update)
                clsBookingRoom.DeleteAllBookingRoomForBookingID(_Booking.BookingID);

            foreach(DataGridViewRow row in dgvListRoomsForBooking.Rows)
            {
                clsBookingRoom BookingRoom = new clsBookingRoom();
                BookingRoom.BookingID = _Booking.BookingID;
                BookingRoom.RoomID =(int) row.Cells[0].Value;
                BookingRoom.Save();
            }
        }
        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save Payment

            _Payment.PaymentDate = DateTime.Now;
            _Payment.Notes = txtNotes.Text.Trim();
            _Payment.PaymentMethod = (rbCash.Checked) ? clsPayment.enPaymentMethod.Cash :
                clsPayment.enPaymentMethod.CreditCard;
            _Payment.PaymentAmount = Convert.ToSingle(lblPaymentAmount.Text);
            _Payment.CreatedByEmployeeID =  clsGlobal.CurrentEmployee.EmployeeID;

            if (!_Payment.Save())
            {
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               

           

            lblPaymentID.Text = _Payment.PaymentID.ToString() ;

            // Save Booking

            _Booking.GuestID = ctrlGuestInfoWithFilter1.GuestID;
            _Booking.PaymentID = _Payment.PaymentID;
            _Booking.BookingStatus = clsBooking.enBookingStatus.Pending;
            _Booking.CheckInDate = Convert.ToDateTime(lblCheckInDate.Text);
            _Booking.CheckOutDate = dtpCheckOutDate.Value;
            _Booking.NumberAdults =(short) nudNumberAdults.Value;
            _Booking.NumberChildren =(short) nudNumberChildren.Value;
            _Booking.BookingAmount = Convert.ToSingle(lblBookingAmount.Text);
            _Booking.Discount = Convert.ToSingle(lblDiscount.Text);
            _Booking.CreatedByEmployeeID = clsGlobal.CurrentEmployee.EmployeeID;

            if (!_Booking.Save())
            {
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               

            lblBookingID.Text = _Booking.BookingID.ToString();

            // Save BookingRooms
            SaveBookingRooms();
            
            this.Text = lblTitle.Text = "Edit Booking ";
            _Mode = enMode.Update;
            MessageBox.Show("Data Saved Successfully ", "Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }
    }
}

