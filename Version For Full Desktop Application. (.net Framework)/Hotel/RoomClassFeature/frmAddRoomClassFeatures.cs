using Hotel.BedTypes;
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

namespace Hotel.RoomClassFeature
{
    public partial class frmAddRoomClassFeatures : Form
    {
        private int _RoomClassFeatureID = -1;
        private int _RoomClassID = -1;
        private clsRoomClassFeature _RoomClassFeature;
        public frmAddRoomClassFeatures(int RoomClassID)
        {
            InitializeComponent();
            _RoomClassID = RoomClassID;
        }
        private void _FillFeaturesInCompoBox()
        {
            DataTable dt = clsFeature.GetAllFeatures();
            foreach (DataRow Row in dt.Rows)
            {
                cbFeatures.Items.Add(Row["FeatureName"]);
            }
            if (cbFeatures.Items.Count >= 0)
                cbFeatures.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddRoomClassFeatures_Load(object sender, EventArgs e)
        {
            _FillFeaturesInCompoBox();
         
             this.Text = lblTitle.Text = "Add Room Class Features";
             _RoomClassFeature = new clsRoomClassFeature();
            lblRoomClassFeaturesID.Text = "[????]";
        }

        private void btnAddFeture_Click(object sender, EventArgs e)
        {
            frmAddEditFeature frm = new frmAddEditFeature();
            frm.ShowDialog();
            _FillFeaturesInCompoBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int FeatureID = clsFeature.Find(cbFeatures.Text.Trim()).FeatureID;
            if (clsRoomClassFeature.IsRoomClassFeatureExistByFeatureAndRoomClass(FeatureID, _RoomClassID))
            {
                MessageBox.Show("this Feature already exist in this room class", " Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _RoomClassFeature.FeatureID = FeatureID;
            _RoomClassFeature.RoomClassID = _RoomClassID;
            if (_RoomClassFeature.Save())
            {
                lblRoomClassFeaturesID.Text = _RoomClassFeature.RoomClassFeatureID.ToString();

                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
