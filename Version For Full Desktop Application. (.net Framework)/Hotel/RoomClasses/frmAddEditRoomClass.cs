using DVLD.Global_Classes;
using DVLD_Buisness;
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
using TheArtOfDevHtmlRenderer.Adapters;

namespace Hotel.RoomClasses
{
    public partial class frmAddEditRoomClass : Form
    {
        public delegate void DataBackEventHandler(object sender, int RoomClassID);

        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _RoomClassID = -1;
        private clsRoomClass _RoomClass;
        public frmAddEditRoomClass(int RoomClassID)
        {
            InitializeComponent();
            _RoomClassID = RoomClassID;
            _Mode = enMode.Update;
        }

        public frmAddEditRoomClass()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _RoomClass.RoomClassID);
            this.Close();
        }

        private void txtRoomClass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomClass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRoomClass, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtRoomClass, null);
            }

            if (txtRoomClass.Text.Trim() != _RoomClass.RoomClassName && clsRoomClass.IsRoomClassExist(txtRoomClass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRoomClass, "class already exist !");

            }
            else
            {
                errorProvider1.SetError(txtRoomClass, null);
            }
        }

        private void txtBasePrice_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtBasePrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBasePrice, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBasePrice, null);
            }

            
            if (!clsValidation.IsNumber(txtBasePrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBasePrice, "Invalide Number !");

            }
            else
            {
                errorProvider1.SetError(txtBasePrice, null);
            }
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Room Class";
                _RoomClass = new clsRoomClass();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Room Class";
            }
            lblRoomClassID.Text = "[????]";
            
            txtBasePrice.Text = "";
            txtRoomClass.Text = "";
        }
        private void _LoadData()
        {
            _RoomClass = clsRoomClass.Find(_RoomClassID);
            if (_RoomClass == null)
            {
                MessageBox.Show("this form well be closed because No Room Class With ID : " + _RoomClassID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            lblRoomClassID.Text = _RoomClass.RoomClassID.ToString();
            txtBasePrice.Text = _RoomClass.BasePrice.ToString();
            txtRoomClass.Text = _RoomClass.RoomClassName;
        }
        private void frmAddEditRoomClass_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _RoomClass.BasePrice = Convert.ToSingle(txtBasePrice.Text.Trim());
            _RoomClass.RoomClassName = txtRoomClass.Text.Trim();
            if (_RoomClass.Save())
            {

                this.Text = lblTitle.Text = "Edit Room Class ";
                _Mode = enMode.Update;
                lblRoomClassID.Text = _RoomClass.RoomClassID.ToString();
                
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
