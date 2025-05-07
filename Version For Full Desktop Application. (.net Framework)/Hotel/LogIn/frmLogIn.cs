using DVLD.Global.Classes;
using DVLD.Global_Classes;
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

namespace Hotel.LogIn
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            chkRememberMe.Checked = clsGlobal.GetStoredCredential(ref UserName, ref Password);

            txtUserName.Text = UserName;
            txtPassword.Text = Password;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string PasswordHashed = clsCryptography.ComputeHash(txtPassword.Text.Trim());
            clsEmployee Employee = clsEmployee.FindByUserNameAndPassword(txtUserName.Text.Trim(), PasswordHashed);
            if (Employee == null)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalide UserName Or Password !", "Wrong Credintials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (chkRememberMe.Checked)
                 clsGlobal.RememberUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            else
                 clsGlobal.RememberUserNameAndPassword("", "");
            if (!Employee.IsActive)
            {
                 MessageBox.Show("Your account is not active , please contact your admin !", "In Active Account",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }

            clsGlobal.CurrentEmployee = Employee;
            this.Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }
    }
}
