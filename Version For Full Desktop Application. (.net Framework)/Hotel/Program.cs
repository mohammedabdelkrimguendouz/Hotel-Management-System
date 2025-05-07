
using Hotel.BedTypes;
using Hotel.Bookings;
using Hotel.Employees;
using Hotel.Features;
using Hotel.Floors;
using Hotel.Guests;
using Hotel.LogIn;
using Hotel.Maintenance_Requests;
using Hotel.RoomClasses;
using Hotel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
            //Application.Run(new frmListBookings());
        }
    }
}
