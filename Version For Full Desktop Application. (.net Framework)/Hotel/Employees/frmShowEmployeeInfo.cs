using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Employees
{
    public partial class frmShowEmployeeInfo : Form
    {
        public frmShowEmployeeInfo(int EmployeeID)
        {
            InitializeComponent();
            ctrlEmployeeCardInfo1.LoadEmployeeInfo(EmployeeID);
        }

        public frmShowEmployeeInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlEmployeeCardInfo1.LoadEmployeeInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
