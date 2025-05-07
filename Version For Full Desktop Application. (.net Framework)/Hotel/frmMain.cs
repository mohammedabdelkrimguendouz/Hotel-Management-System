using DVLD.Global_Classes;
using Hotel.BedTypes;
using Hotel.Bookings;
using Hotel.Employees;
using Hotel.Features;
using Hotel.Floors;
using Hotel.Guests;
using Hotel.LogIn;
using Hotel.Maintenance_Requests;
using Hotel.Payments;
using Hotel.RoomClasses;
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

namespace Hotel
{
    public partial class frmMain : Form
    {
        private frmLogIn _frmLogIn;

        public frmMain(frmLogIn frmLogIn)
        {
            InitializeComponent();
            _frmLogIn = frmLogIn;
        }

        private void currentEmployeeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowEmployeeInfo frm = new frmShowEmployeeInfo(clsGlobal.CurrentEmployee.EmployeeID);
            frm.ShowDialog();
        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentEmployee.EmployeeID);
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsGlobal.CurrentEmployee = null;
            _frmLogIn.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEmployee frm = new frmListEmployee();
            frm.ShowDialog();
        }

        private void guestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListGuests frm = new frmListGuests();
            frm.ShowDialog();
        }

        private void addBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditBooking frm = new frmAddEditBooking();
            frm.ShowDialog();
        }

        private void listBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBookings frm = new frmListBookings();
            frm.ShowDialog();
        }

        
        private void managePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPayments frm = new frmListPayments();
            frm.ShowDialog();
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListMaintenanceRequests frm = new frmListMaintenanceRequests();
            frm.ShowDialog();
        }

        private void manageFloorstoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListFloors frm = new frmListFloors();
            frm.ShowDialog();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRooms frm = new frmListRooms();
            frm.ShowDialog();
        }

        private void bedTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBedTypes frm = new frmListBedTypes();
            frm.ShowDialog();
        }

        private void roomClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListRoomClasses frm = new frmListRoomClasses();
            frm.ShowDialog();
        }

        private void featuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListFeatures frm = new frmListFeatures();
            frm.ShowDialog();
        }

        private  void _UpdateBookingStatusIfCompleted()
        {
            clsBooking.UpdateBookingStatusIfCompleted();
        }
        private  void frmMain_Load(object sender, EventArgs e)
        {
            Parallel.Invoke(_UpdateBookingStatusIfCompleted);
        }
    }
}
