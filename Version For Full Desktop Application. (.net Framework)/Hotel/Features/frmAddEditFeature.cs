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

namespace Hotel.Features
{
    public partial class frmAddEditFeature : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _FeatureID = -1;
        private clsFeature _Feature;
        public frmAddEditFeature()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditFeature(int FeatureID)
        {
            InitializeComponent();
            _FeatureID = FeatureID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add New Feature";
                _Feature = new clsFeature();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Feature";
            }
            lblFeatureID.Text = "[????]";
            txtFeatureName.Text = "";
            txtDescription.Text = "";
        }

        private void _LoadData()
        {
            _Feature = clsFeature.Find(_FeatureID);
            if (_Feature == null)
            {
                MessageBox.Show("this form well be closed because No Feature With ID : " + _FeatureID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblFeatureID.Text = _Feature.FeatureID.ToString();
            txtFeatureName.Text = _Feature.FeatureName;
            txtDescription.Text = _Feature.Description;
        }
        private void frmAddEditFeature_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtFeatureName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeatureName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFeatureName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFeatureName, null);
            }

            //Make sure the national number is not used by another person
            if (txtFeatureName.Text.Trim() != _Feature.FeatureName &&clsFeature.IsFeatureExist(txtFeatureName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFeatureName, "Feature Name  is exist  !");

            }
            else
            {
                errorProvider1.SetError(txtFeatureName, null);
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
            _Feature.FeatureName = txtFeatureName.Text.Trim();
            _Feature.Description = txtDescription.Text.Trim();

            if (_Feature.Save())
            {

                this.Text = lblTitle.Text = "Edit Feature ";
                _Mode = enMode.Update;
                lblFeatureID.Text = _Feature.FeatureID.ToString();

                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
