using DVLD.Global_Classes;
using DVLD_Buisness;
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

namespace Hotel.BedTypes
{
    public partial class frmAddEditBedType : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _BedTypeID = -1;
        private clsBedType _BedType;
        public frmAddEditBedType()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditBedType(int BedTypeID)
        {
            InitializeComponent();
            _BedTypeID = BedTypeID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New BedType";
                _BedType = new clsBedType();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit BedType";
            }
            lblBedTypeID.Text = "[????]";
            txtBedTypeName.Text = "";
            txtDescription.Text = "";
        }

        private void _LoadData()
        {
            _BedType =clsBedType.Find(_BedTypeID);
            if (_BedType == null)
            {
                MessageBox.Show("this form well be closed because No BedType With ID : " + _BedTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblBedTypeID.Text = _BedType.BedTypeID.ToString();
            txtBedTypeName.Text = _BedType.BedTypeName;
            txtDescription.Text = _BedType.Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditBedType_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtBedTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBedTypeName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBedTypeName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtBedTypeName, null);
            }

            //Make sure the national number is not used by another person
            if (txtBedTypeName.Text.Trim() != _BedType.BedTypeName && clsBedType.IsBedTypeExist(txtBedTypeName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBedTypeName, "Bed Type Name  is exist  !");

            }
            else
            {
                errorProvider1.SetError(txtBedTypeName, null);
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
            _BedType.BedTypeName = txtBedTypeName.Text.Trim();
            _BedType.Description = txtDescription.Text.Trim();

            if (_BedType.Save())
            {

                this.Text = lblTitle.Text = "Edit BedType ";
                _Mode = enMode.Update;
                lblBedTypeID.Text = _BedType.BedTypeID.ToString();
        
                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
