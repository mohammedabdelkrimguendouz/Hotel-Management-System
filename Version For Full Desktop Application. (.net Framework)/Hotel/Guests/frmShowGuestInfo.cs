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
    public partial class frmShowGuestInfo : Form
    {
        public frmShowGuestInfo(int GuestID)
        {
            InitializeComponent();
            ctrlGuestCardInfo1.LoadGuestInfo(GuestID);
        }
        public frmShowGuestInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlGuestCardInfo1.LoadGuestInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
