using Hotel.Features;
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
    public partial class frmListFeatures : Form
    {
        private static DataTable _dtAllFeatures;
        public frmListFeatures()
        {
            InitializeComponent();
        }

        private void frmListFeatures_Load(object sender, EventArgs e)
        {
            _dtAllFeatures = clsFeature.GetAllFeatures();
            dgvListFeatures.DataSource = _dtAllFeatures;
            lblRecordsCount.Text = dgvListFeatures.Rows.Count.ToString();

            if (dgvListFeatures.Rows.Count > 0)
            {
                dgvListFeatures.Columns["FeatureID"].HeaderText = "ID";
                dgvListFeatures.Columns["FeatureID"].Width = 70;


                dgvListFeatures.Columns["FeatureName"].HeaderText = "Name";
                dgvListFeatures.Columns["FeatureName"].Width = 150;

                dgvListFeatures.Columns["Description"].HeaderText = "Description";
                //dgvListFeatures.Columns["Description"].Width = 150;
            }
        }

        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            frmAddEditFeature frm = new frmAddEditFeature();
            frm.ShowDialog();
            frmListFeatures_Load(null, null);
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditFeature frm = new frmAddEditFeature();
            frm.ShowDialog();
            frmListFeatures_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int FeatureID= (int)dgvListFeatures.CurrentRow.Cells[0].Value;
            frmAddEditFeature frm = new frmAddEditFeature(FeatureID);
            frm.ShowDialog();
            frmListFeatures_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int FeatureID = (int)dgvListFeatures.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Feature [" + FeatureID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsFeature.DeleteFeature(FeatureID))
            {
                MessageBox.Show("Feature Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListFeatures_Load(null, null);
            }
            else
            {
                MessageBox.Show("Feature Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Feature ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            txtfilterValue.Visible = (cbFilter.Text != "None");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }
            _dtAllFeatures.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListFeatures.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Feature ID":
                    FilterColumn = "FeatureID";
                    break;
                case "Feature Name":
                    FilterColumn = "FeatureName";
                    break;
                case "Description":
                    FilterColumn = "Description";
                    break;
                
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllFeatures.DefaultView.RowFilter = "";
            else if (FilterColumn == "FeatureID")
                _dtAllFeatures.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            else
                _dtAllFeatures.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListFeatures.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
