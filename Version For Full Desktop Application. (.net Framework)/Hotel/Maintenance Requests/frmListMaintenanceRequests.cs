using Hotel.Employees;
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

namespace Hotel.Maintenance_Requests
{
    public partial class frmListMaintenanceRequests : Form
    {
        private static DataTable _dtAllMaintenanceRequests;
        public frmListMaintenanceRequests()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListMaintenanceRequests_Load(object sender, EventArgs e)
        {
            _dtAllMaintenanceRequests =clsMaintenanceRequest.GetAllMaintenanceRequests();
            dgvListMaintenanceRequests.DataSource = _dtAllMaintenanceRequests;
            lblRecordsCount.Text = dgvListMaintenanceRequests.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dgvListMaintenanceRequests.Rows.Count > 0)
            {
                dgvListMaintenanceRequests.Columns["MaintenanceRequestID"].HeaderText = "M.R ID";
                dgvListMaintenanceRequests.Columns["MaintenanceRequestID"].Width = 120;

                dgvListMaintenanceRequests.Columns["RoomID"].HeaderText = "Room ID";
                dgvListMaintenanceRequests.Columns["RoomID"].Width = 120;

                
                dgvListMaintenanceRequests.Columns["RoomNumber"].HeaderText = "Room Number";
                dgvListMaintenanceRequests.Columns["RoomNumber"].Width = 120;

                dgvListMaintenanceRequests.Columns["FloorNumber"].HeaderText = "Floor Number";
                dgvListMaintenanceRequests.Columns["FloorNumber"].Width = 120;

                dgvListMaintenanceRequests.Columns["MaintenanceRequestDate"].HeaderText = "M.R Date";
                dgvListMaintenanceRequests.Columns["MaintenanceRequestDate"].Width = 140;

                dgvListMaintenanceRequests.Columns["IsCompleted"].HeaderText = "IsCompleted";
                //dgvListMaintenanceRequests.Columns["IsCompleted"].Width = 80;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditMaintenanceRequest frm = new frmAddEditMaintenanceRequest();
            frm.ShowDialog();
            frmListMaintenanceRequests_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int MaintenanceRequestID = (int)dgvListMaintenanceRequests.CurrentRow.Cells[0].Value;
            frmAddEditMaintenanceRequest frm = new frmAddEditMaintenanceRequest(MaintenanceRequestID);
            frm.ShowDialog();
            frmListMaintenanceRequests_Load(null, null);
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditMaintenanceRequest frm = new frmAddEditMaintenanceRequest();
            frm.ShowDialog();
            frmListMaintenanceRequests_Load(null, null);
        }

        private void showDetailestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int MaintenanceRequestID = (int)dgvListMaintenanceRequests.CurrentRow.Cells[0].Value;
            frmShowMaintenanceRequestInfo frm = new frmShowMaintenanceRequestInfo(MaintenanceRequestID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            


            int MaintenanceRequestID = (int)dgvListMaintenanceRequests.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure do you want to delete Maintenance Request [" + MaintenanceRequestID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)

                return;

            if (clsMaintenanceRequest.DeleteMaintenanceRequest(MaintenanceRequestID))
            {
                MessageBox.Show("Maintenance Request Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListMaintenanceRequests_Load(null, null);
            }
            else
                MessageBox.Show("Error deleted Maintenance Request", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsCompleted.Visible = (cbFilter.Text == "Is Completed");
            if (cbIsCompleted.Visible)
                cbIsCompleted.SelectedIndex = 0;

            txtfilterValue.Visible = (cbFilter.Text != "Is Completed") && (cbFilter.Text != "None");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }

            _dtAllMaintenanceRequests.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListMaintenanceRequests.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Maintenance Request ID":
                    FilterColumn = "MaintenanceRequestID";
                    break;
                case "Room ID":
                    FilterColumn = "RoomID";
                    break;
                case "Room Number":
                    FilterColumn = "RoomNumber";
                    break;
                case "Floor Number":
                    FilterColumn = "FloorNumber";
                    break;
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllMaintenanceRequests.DefaultView.RowFilter = "";  
            else
                 _dtAllMaintenanceRequests.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListMaintenanceRequests.Rows.Count.ToString();
        }

        private void cbIsCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterIColumn = "IsCompleted";
            string FilterValue = "";
            switch (cbIsCompleted.Text)
            {
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (cbIsCompleted.Text == "All")
                _dtAllMaintenanceRequests.DefaultView.RowFilter = "";
            else
                _dtAllMaintenanceRequests.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterIColumn, FilterValue);
            lblRecordsCount.Text = dgvListMaintenanceRequests.Rows.Count.ToString();
        }

        private void setCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MaintenanceRequestID = (int)dgvListMaintenanceRequests.CurrentRow.Cells[0].Value;
            clsMaintenanceRequest MaintenanceRequest = clsMaintenanceRequest.Find(MaintenanceRequestID);

            if (MaintenanceRequest == null)
                return;

            if(MaintenanceRequest.SetCompleteMaintenance())
            {
                MessageBox.Show("Maintenance Request Completed Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListMaintenanceRequests_Load(null, null);
            }
            else
                MessageBox.Show("Error to  Completed Maintenance Request", "Error ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);



        }

        private void cmsListMaintenanceRequests_Opening(object sender, CancelEventArgs e)
        {
            bool IsCompleted = (bool)dgvListMaintenanceRequests.CurrentRow.Cells[5].Value;
            setCompletedToolStripMenuItem.Enabled = !IsCompleted;
            deleteToolStripMenuItem.Enabled = IsCompleted;
        }
    }
}
