using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Maintenance_Requests
{
    public partial class frmShowMaintenanceRequestInfo : Form
    {
        private int _MaintenanceRequestID = -1;
        public frmShowMaintenanceRequestInfo(int maintenanceRequestID)
        {
            InitializeComponent();
            _MaintenanceRequestID = maintenanceRequestID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowMaintenanceRequestInfo_Load(object sender, EventArgs e)
        {
            ctrlMaintenanceRequestCardInfo1.LoadMaintenanceRequestInfo(_MaintenanceRequestID);
        }
    }
}
