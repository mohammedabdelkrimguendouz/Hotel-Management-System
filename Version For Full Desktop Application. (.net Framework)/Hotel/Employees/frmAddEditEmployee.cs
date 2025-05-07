using DVLD.Global.Classes;
using DVLD.Global_Classes;
using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Guna.UI2.WinForms;
using Hotel.Properties;
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
    public partial class frmAddEditEmployee : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _EmployeeID = -1;
        private clsEmployee _Employee;
        public frmAddEditEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            _Mode = enMode.Update;
        }
        public frmAddEditEmployee()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.Text = lblTitle.Text = "Add New Employee";
                pbEmployeeImage.ImageLocation = null;
                _Employee = new clsEmployee();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Employee";
                pbEmployeeImage.ImageLocation = "";
            }
            lblPersonID.Text = "[????]";
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
            txtConfirmPassword.Text = "";
            txtUserName.Text = "";
            lblHireDate.Text = clsFormat.DateToShort(DateTime.Now);
            chkIsActive.Checked = true;
            txtSalary.Text = "";

        }

        private void _LoadData()
        {
            _Employee = clsEmployee.FindByEmployeeID(_EmployeeID);
            if (_Employee == null)
            {
                MessageBox.Show("this form well be closed because No Employee With ID : " + _EmployeeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _Employee.PersonID.ToString();
            txtAddress.Text = _Employee.Address;
            txtFirstName.Text = _Employee.FirstName;
            txtLastName.Text = _Employee.LastName;
            txtNationalNo.Text = _Employee.NationalNo;
            txtMidlleName.Text = _Employee.MidlleName;
            txtEmail.Text = _Employee.Email;
            txtPhone.Text = _Employee.Phone;
            txtSalary.Text = _Employee.Salary.ToString();
            dtpDateOfBirth.Value = _Employee.DateOfBirth;

            cbCountry.SelectedIndex = cbCountry.FindString(_Employee.CountryInfo.CountryName);
            rbMale.Checked = (_Employee.Gender == clsPerson.enGender.Male) ? true : rbFemale.Checked = true; ;
           
            lblEmployeeID.Text = _Employee.EmployeeID.ToString();
            txtUserName.Text = _Employee.UserName;
            chkIsActive.Checked = _Employee.IsActive;
            lblHireDate.Text = clsFormat.DateToShort(_Employee.HireDate);
            pbEmployeeImage.Image =clsUtil.ConvertByteArrayToImage(_Employee.Image);
            llRemoveImage.Visible = true;
        }
        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode==enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcEmployeeInfo.SelectedTab = tcEmployeeInfo.TabPages["tpEmployeeInfo"];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcEmployeeInfo.SelectedTab = tcEmployeeInfo.TabPages["tpPersonInfo"];
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode==enMode.AddNew && txtPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field cannot be empty !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match password !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }

            if (_Employee.UserName != txtUserName.Text.Trim() && clsEmployee.IsEmployeeExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name is used for another User !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Choose Image ";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbEmployeeImage.ImageLocation = openFileDialog1.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbEmployeeImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }

        private void pbEmployeeImage_Validating(object sender, CancelEventArgs e)
        {
            if (pbEmployeeImage.ImageLocation==null)
            {
                e.Cancel = true;
                errorProvider1.SetError(pbEmployeeImage, "Please set employee image !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(pbEmployeeImage, null);
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

            string PasswordHashed = clsCryptography.ComputeHash(txtPassword.Text.Trim());

            _Employee.UserName = txtUserName.Text.Trim();
            _Employee.Password = PasswordHashed;
            _Employee.IsActive = chkIsActive.Checked;
            _Employee.HireDate = Convert.ToDateTime(lblHireDate.Text);

            _Employee.FirstName = txtFirstName.Text.Trim();
            _Employee.MidlleName = txtMidlleName.Text.Trim();
            _Employee.NationalNo = txtNationalNo.Text.Trim();
            _Employee.LastName = txtLastName.Text.Trim();
            _Employee.DateOfBirth = dtpDateOfBirth.Value;
            _Employee.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Employee.Phone = txtPhone.Text.Trim();
            _Employee.Email = txtEmail.Text.Trim();
            _Employee.NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;
            _Employee.Address = txtAddress.Text.Trim();
            _Employee.Salary = Convert.ToSingle(txtSalary.Text.Trim());

            if (pbEmployeeImage.ImageLocation!="")
                  _Employee.Image = clsUtil.ReadImageFile(pbEmployeeImage.ImageLocation);
            
            if (_Employee.Save())
            {
                this.Text = lblTitle.Text = "Edit Employee ";
                _Mode = enMode.Update;
                lblEmployeeID.Text = _Employee.EmployeeID.ToString();
                lblPersonID.Text = _Employee.PersonID.ToString();
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Employee.EmployeeID);

            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
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
            if (txtNationalNo.Text.Trim() != _Employee.NationalNo && clsEmployee.IsEmployeeExistForNationalNo(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is exist in the hotel !");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSalary, "This field is required!");
                return;
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtSalary, null);
            }

            if (clsValidation.IsNumber(txtSalary.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSalary, "Invalide Number!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtSalary, null);
            }
        }
    }
}
