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
    public partial class frmShowBookingInfo : Form
    {
        private int _BookingID = -1;
        public frmShowBookingInfo(int bookingID)
        {
            InitializeComponent();
            _BookingID = bookingID;
        }

        private void frmShowBookingInfo_Load(object sender, EventArgs e)
        {
            ctrlBookingCardInfo1.LoadBookingnfo(_BookingID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
