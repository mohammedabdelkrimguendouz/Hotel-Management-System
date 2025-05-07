using Hotel.Contact;
using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hotel.Employees
{
    public partial class frmListEmployee : Form
    {
        private static DataTable _dtAllEmmployees;
        public frmListEmployee()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee frm = new frmAddEditEmployee();
            frm.ShowDialog();
            frmListEmployee_Load(null, null);
        }

        private void frmListEmployee_Load(object sender, EventArgs e)
        {
            _dtAllEmmployees = clsEmployee.GetAllEmployees();
            dgvListEmployees.DataSource = _dtAllEmmployees;
            lblRecordsCount.Text = dgvListEmployees.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dgvListEmployees.Rows.Count > 0)
            {
                dgvListEmployees.Columns["EmployeeID"].HeaderText = "Employee ID";
                dgvListEmployees.Columns["EmployeeID"].Width = 95;

                dgvListEmployees.Columns["PersonID"].HeaderText = "Person ID";
                dgvListEmployees.Columns["PersonID"].Width = 80;

               

                dgvListEmployees.Columns["FullName"].HeaderText = "Full Name";
                dgvListEmployees.Columns["FullName"].Width = 190;

                dgvListEmployees.Columns["UserName"].HeaderText = "User Name";
                dgvListEmployees.Columns["UserName"].Width = 120;

                dgvListEmployees.Columns["HireDate"].HeaderText = "Hire Date";
                dgvListEmployees.Columns["HireDate"].Width = 90;

                dgvListEmployees.Columns["EndDate"].HeaderText = "End Date";
                dgvListEmployees.Columns["EndDate"].Width = 90;



                dgvListEmployees.Columns["IsActive"].HeaderText = "Is Active";
                dgvListEmployees.Columns["IsActive"].Width = 80;

            }
        }

        private void changePasswordtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmChangePassword frm = new frmChangePassword(EmployeeID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure do you want to delete Employee [" + EmployeeID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)

                return;

            if (clsEmployee.DeleteEmployee(EmployeeID))
            {
                    MessageBox.Show("Emoloyee Deleted Successfully", "Successful", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    frmListEmployee_Load(null,null);
            }
            else
                    MessageBox.Show("Error deleted Employee", "Error Delete", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            
        }

        private void showDetailestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmShowEmployeeInfo frm = new frmShowEmployeeInfo(EmployeeID);
            frm.ShowDialog();
            frmListEmployee_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            clsEmployee Employee = clsEmployee.FindByEmployeeID(EmployeeID);
            if (Employee == null)
                return;

            frmSendEmail frm = new frmSendEmail(Employee.Email);
            frm.ShowDialog();
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID" || cbFilter.Text == "Employee ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsActive.Visible = (cbFilter.Text == "Is Active");
            if (cbIsActive.Visible)
                cbIsActive.SelectedIndex = 0;

            txtfilterValue.Visible = (cbFilter.Text != "Is Active") && (cbFilter.Text != "None");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }

            _dtAllEmmployees.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListEmployees.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Employee ID":
                    FilterColumn = "EmployeeID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllEmmployees.DefaultView.RowFilter = "";
            else if (FilterColumn == "PersonID" || FilterColumn == "EmployeeID")
                _dtAllEmmployees.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            else
                _dtAllEmmployees.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListEmployees.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterIColumn = "IsActive";
            string FilterValue = "";
            switch (cbIsActive.Text)
            {
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (cbIsActive.Text == "All")
                _dtAllEmmployees.DefaultView.RowFilter = "";
            else
                _dtAllEmmployees.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterIColumn, FilterValue);
            lblRecordsCount.Text = dgvListEmployees.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            frmAddEditEmployee frm = new frmAddEditEmployee();
            frm.ShowDialog();
            frmListEmployee_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmAddEditEmployee frm = new frmAddEditEmployee(EmployeeID);
            frm.ShowDialog();
            frmListEmployee_Load(null, null);
        }
    }
}
