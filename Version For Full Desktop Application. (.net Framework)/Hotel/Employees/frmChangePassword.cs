using DVLD.Global.Classes;
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

namespace Hotel.Employees
{
    public partial class frmChangePassword : Form
    {
        private int _EmployeeID=-1;
        private clsEmployee _Employee;
        public frmChangePassword(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtConfirmPassword.Focus();
            _Employee = clsEmployee.FindByEmployeeID(_EmployeeID);
            if (_Employee == null)
            {
                MessageBox.Show("No Employee With ID = " + _EmployeeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                pChangePassword.Enabled = false;
                return;
            }
            ctrlEmployeeCardInfo1.LoadEmployeeInfo(_EmployeeID);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match password !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtNewPassword, "This field cannot be empty !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Current Password cannot be empty !");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            string PasswordHashed = clsCryptography.ComputeHash(txtCurrentPassword.Text.Trim());
            if (PasswordHashed != _Employee.Password)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string NewPasswordHashed = clsCryptography.ComputeHash(txtNewPassword.Text.Trim());

            _Employee.Password = NewPasswordHashed;
            if (_Employee.Save())
            {
                MessageBox.Show("Password Changed successfully", "Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show(" Password was not Changed successfully", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
