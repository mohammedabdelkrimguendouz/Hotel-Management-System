using Hotel.Features;
//using Hotel.RoomClassFeatures;
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

namespace Hotel.RoomClassFeature
{
    public partial class frmShowListFeaturesForRoomClass : Form
    {
        private int _RoomClassID = -1;
        private clsRoomClass _RoomClass;
        private static DataTable _dtAllFeaturesForRoomClass;
        public frmShowListFeaturesForRoomClass(int RoomClassID)
        {
            InitializeComponent();
            _RoomClassID = RoomClassID;
        }

        private void _RefrechListBedFeaturesForRoomClass()
        {
            _dtAllFeaturesForRoomClass = clsRoomClassFeature.GetAllFeaturesForRoomClass(_RoomClassID);

            dgvFeaturesForRoomClass.DataSource = _dtAllFeaturesForRoomClass;
            lblRecordsCount.Text = dgvFeaturesForRoomClass.Rows.Count.ToString();

            if (dgvFeaturesForRoomClass.Rows.Count > 0)
            {

                dgvFeaturesForRoomClass.Columns["RoomClassFeatureID"].HeaderText = "Room Class Feature ID";
                dgvFeaturesForRoomClass.Columns["RoomClassFeatureID"].Width = 150;

                dgvFeaturesForRoomClass.Columns["FeatureID"].HeaderText = "Feature ID";
                dgvFeaturesForRoomClass.Columns["FeatureID"].Width = 90;


                dgvFeaturesForRoomClass.Columns["FeatureName"].HeaderText = "Feature Name";
                //dgvFeaturesForRoomClass.Columns["BedFeatureName"].Width = 150;

                
            }
        }
        private void frmShowListFeaturesForRoomClass_Load(object sender, EventArgs e)
        {
            _RoomClass = clsRoomClass.Find(_RoomClassID);
            if (_RoomClass == null)
            {
                MessageBox.Show("No Room class With ID = " + _RoomClassID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddNew.Enabled = false;
                dgvFeaturesForRoomClass.Enabled = false;
                return;
            }
            lblClassName.Text = _RoomClass.RoomClassName;
            _RefrechListBedFeaturesForRoomClass();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddRoomClassFeatures frm = new frmAddRoomClassFeatures(_RoomClassID);
            frm.ShowDialog();
            _RefrechListBedFeaturesForRoomClass();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassFeatureID = (int)dgvFeaturesForRoomClass.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Room Class Feature [" + RoomClassFeatureID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsRoomClassFeature.DeleteRoomClassFeature(RoomClassFeatureID))
            {
                MessageBox.Show(" Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                _RefrechListBedFeaturesForRoomClass();
            }
            else
            {
                MessageBox.Show("Error  deleted ", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddRoomClassFeatures frm = new frmAddRoomClassFeatures(_RoomClassID);
            frm.ShowDialog();
            _RefrechListBedFeaturesForRoomClass();
        }
    }
}
