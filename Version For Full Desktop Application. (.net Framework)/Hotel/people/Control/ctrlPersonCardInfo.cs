using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Hotel.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buisness.clsPerson;

namespace Hotel
{
    public partial class ctrlPersonCardInfo : UserControl
    {
        private int _PersonID = -1;
        public int PersonID { get { return _PersonID; } }

        private clsPerson _Person;
        public clsPerson SelectedPersonInfo { get { return _Person; } }
        public ctrlPersonCardInfo()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person With ID = " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();

        }
        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblPhone.Text = _Person.Phone;
            lblGender.Text = (_Person.Gender == clsPerson.enGender.Male) ? "Male" : "Female";
            pbGender.Image = (_Person.Gender == clsPerson.enGender.Male) ? Resources.male : Resources.female;
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person With National Number = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {
            lblAddress.Text = "[????]";
            lblCountry.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblName.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPhone.Text = "[????]";
            lblPersonID.Text = "[????]";
            _PersonID = -1;
        }

        
    }
}
