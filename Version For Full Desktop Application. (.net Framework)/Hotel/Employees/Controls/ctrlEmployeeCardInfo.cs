using DVLD.Global_Classes;
using DVLD_Buisness.Global_Classes;
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
    public partial class ctrlEmployeeCardInfo : UserControl
    {
        private int _EmployeeID = -1;
        public int EmployeeID { get { return _EmployeeID; } }

        private clsEmployee _Employee;
        public clsEmployee SelectedEmployeeInfo { get { return _Employee; } }
        public ctrlEmployeeCardInfo()
        {
            InitializeComponent();
        }
        public void LoadEmployeeInfo(int EmployeeID)
        {
            _Employee = clsEmployee.FindByEmployeeID(EmployeeID);
            if (_Employee == null)
            {
                ResetEmployeeInfo();
                MessageBox.Show("No Employee With ID = " + EmployeeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillEmployeeInfo();

        }
        private void _FillEmployeeInfo()
        {
            ctrlPersonCardInfo1.LoadPersonInfo(_Employee.PersonID);
            _EmployeeID = _Employee.EmployeeID;
            llEditEmployeeInfo.Enabled = true;
            lblEmployeeID.Text = _Employee.EmployeeID.ToString();
            lblHireDate.Text = clsFormat.DateToShort(_Employee.HireDate);
            lblEndDate.Text = (_Employee.EndDate != null) ? _Employee.EndDate.ToString() : "Not Yet";
            lblUserName.Text = _Employee.UserName;
            lblIsActive.Text = (_Employee.IsActive) ? "Yes" : "No";
            pbEmployeeImage.Image = clsUtil.ConvertByteArrayToImage(_Employee.Image);
            lblSalary.Text = _Employee.Salary.ToString();
            
        }
        public void LoadEmployeeInfo(string NationalNo)
        {
            _Employee = clsEmployee.FindByNationalNo(NationalNo);
            if (_Employee == null)
            {
                ResetEmployeeInfo();
                MessageBox.Show("No Employee With National No = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillEmployeeInfo();
        }

        public void ResetEmployeeInfo()
        {
            ctrlPersonCardInfo1.ResetPersonInfo();
            lblIsActive.Text = "[????]";
            lblEmployeeID.Text = "[????]";
            lblHireDate.Text= "[????]";
            lblEndDate.Text= "[????]";
            lblUserName.Text= "[????]";
            lblSalary.Text = "[$$$$]";
            pbEmployeeImage.ImageLocation = null;
            llEditEmployeeInfo.Enabled = false;
            _EmployeeID = -1;
        }
        private void llEditEmployeeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditEmployee frm = new frmAddEditEmployee(_EmployeeID);
            frm.ShowDialog();
            LoadEmployeeInfo(_EmployeeID);
        }
    }
}
