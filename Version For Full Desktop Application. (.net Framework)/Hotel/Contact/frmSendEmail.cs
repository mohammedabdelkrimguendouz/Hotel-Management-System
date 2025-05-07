using DVLD.Global.Classes;
using DVLD_Buisness.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Contact
{
    public partial class frmSendEmail : Form
    {
        private string _Email = "";
        public frmSendEmail()
        {
            InitializeComponent();
        }
        public frmSendEmail(string Email)
        {
            InitializeComponent();
            _Email = Email;
        }

        private void frmSendEmail_Load(object sender, EventArgs e)
        {
            txtEmail.Text = _Email;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalide Formate Email (yourmail'[6-30 Letter]'.gmail.com)");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsContact.SendEmail(txtEmail.Text.Trim(), txtSubject.Text.Trim(), txtBody.Text.Trim()))
            {
                MessageBox.Show("Email Send Successfully ", "Send",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Email is not Send Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
