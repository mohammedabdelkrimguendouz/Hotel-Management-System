using DVLD.Global_Classes;
using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Guna.UI2.WinForms;
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

namespace Hotel.Guests
{
    public partial class frmAddEditGuest : Form
    {
        public class GuestEventArgs : EventArgs
        {
            public int GuestID { get; }
            public string NationalNo {  get; }
            public GuestEventArgs(int GuestID,string NationalNo)
            {
                this.GuestID = GuestID;
                this.NationalNo = NationalNo;
            }
        }

        public delegate void DataBackEventHandler(object sender, GuestEventArgs e );

        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _GuestID = -1;
        private clsGuest _Guest;

        public frmAddEditGuest()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditGuest(int GuestID)
        {
            InitializeComponent();
            _GuestID = GuestID;
            _Mode = enMode.Update;
        }

        private void _FillCountriesInCompoBox()
        {
            DataTable TableCountries = clsCountry.GetAllCountries();
            foreach (DataRow Row in TableCountries.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"]);

            }
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInCompoBox();
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Guest";
                _Guest = new clsGuest();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Guest";
            }
            lblPersonID.Text = "[????]";
            lblGuestID.Text= "[????]";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMidlleName.Text = "";
            txtNationalNo.Text = "";
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-15);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            txtPhone.Text = "";
            txtEmail.Text = "";
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            txtAddress.Text = "";
            rbMale.Checked = true;
            
        }

        private void _LoadData()
        {
            _Guest = clsGuest.FindByGuestID(_GuestID);
            if (_Guest == null)
            {
                MessageBox.Show("this form well be closed because No GuestID With ID : " + _GuestID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblPersonID.Text = _Guest.PersonID.ToString();
            lblGuestID.Text = _Guest.GuestID.ToString();
            txtAddress.Text = _Guest.Address;
            txtFirstName.Text = _Guest.FirstName;
            txtLastName.Text = _Guest.LastName;
            txtNationalNo.Text = _Guest.NationalNo;
            txtMidlleName.Text = _Guest.MidlleName;
            
            txtEmail.Text = _Guest.Email;
            txtPhone.Text = _Guest.Phone;
            dtpDateOfBirth.Value = _Guest.DateOfBirth;
            
            cbCountry.SelectedIndex = cbCountry.FindString(_Guest.CountryInfo.CountryName);
            if (_Guest.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Guest.CreatedByEmployeeID =  clsGlobal.CurrentEmployee.EmployeeID;
            _Guest.FirstName = txtFirstName.Text.Trim();
            _Guest.MidlleName = txtMidlleName.Text.Trim();
            _Guest.NationalNo = txtNationalNo.Text.Trim();
            _Guest.LastName = txtLastName.Text.Trim();
            _Guest.DateOfBirth = dtpDateOfBirth.Value;
            _Guest.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Guest.Phone = txtPhone.Text.Trim();
            _Guest.Email = txtEmail.Text.Trim();
            _Guest.NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;
            _Guest.Address = txtAddress.Text.Trim();
            if (_Guest.Save())
            {

                this.Text = lblTitle.Text = "Edit Guest ";
                _Mode = enMode.Update;
                lblPersonID.Text = _Guest.PersonID.ToString();
                lblGuestID.Text = _Guest.GuestID.ToString();
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, new GuestEventArgs(_Guest.GuestID,_Guest.NationalNo));
            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddEditGuest_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Guna2TextBox Temp = ((Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            

            if (txtEmail.Text.Trim() == "")
                return;

            string EmailAddress = txtEmail.Text.Trim();


            if (!EmailAddress.EndsWith("@gmail.com"))
                 EmailAddress = EmailAddress + "@gmail.com";


            if (!clsValidation.ValidateEmail(EmailAddress))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalide Formate Email(yourmail'[6-30 Letter]'.gmail.com");
            }
            else
            {
                txtEmail.Text = EmailAddress;
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Guest.NationalNo && clsGuest.IsGuestExistForNationalNo(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is exist in the hotel !");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

    }
}
