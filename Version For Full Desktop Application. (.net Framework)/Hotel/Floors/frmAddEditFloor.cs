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

namespace Hotel.Floors
{
    public partial class frmAddEditFloor : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _FloorID = -1;
        private clsFloor _Floor;

        public frmAddEditFloor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditFloor(int FloorID)
        {
            InitializeComponent();
            _FloorID = FloorID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Floor";
                _Floor = new clsFloor();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Floor";
            }
            lblFloorID.Text = "[????]";
            txtFloorAreas .Text = "";
            nudFloorNumber.Value = 1;
        }

        private void _LoadData()
        {
            _Floor = clsFloor.FindByID(_FloorID);
            if (_Floor == null)
            {
                MessageBox.Show("this form well be closed because No Floor With ID : " + _FloorID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblFloorID.Text = _Floor.FloorID.ToString();
            txtFloorAreas.Text = _Floor.FloorArea.ToString();
            nudFloorNumber.Value = _Floor.FloorNumber;
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

            _Floor.FloorArea = Convert.ToSingle(txtFloorAreas.Text.Trim());
            _Floor.FloorNumber =(short) nudFloorNumber.Value;

            if (_Floor.Save())
            {

                this.Text = lblTitle.Text = "Edit Floor ";
                _Mode = enMode.Update;
                lblFloorID.Text = _Floor.FloorID.ToString();

                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddEditFloor_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void nudFloorNumber_Validating(object sender, CancelEventArgs e)
        {
         
            if (nudFloorNumber.Value != _Floor.FloorNumber&&clsFloor.IsNumberFloorExist((short)nudFloorNumber.Value))
            {
                e.Cancel = true;
                errorProvider1.SetError(nudFloorNumber, "Floor Number already Exist  !");

            }
            else
            {
                errorProvider1.SetError(nudFloorNumber, null);
            }
        }

        

        private void txtFloorAreas_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFloorAreas.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFloorAreas, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFloorAreas, null);
            }


            if (!clsValidation.IsNumber(txtFloorAreas.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFloorAreas, "Invalide Number  !");

            }
            else
            {
                errorProvider1.SetError(txtFloorAreas, null);
            }
        }
    }
}
