using Hotel.RoomClassBedTypes;
using Hotel.RoomClasses;
using Hotel.RoomClassFeature;
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

namespace Hotel.RoomClasses
{
    public partial class frmListRoomClasses : Form
    {
        private static DataTable _dtAllRoomClasses;
        public frmListRoomClasses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditRoomClass frm = new frmAddEditRoomClass();
            frm.ShowDialog();
            frmListRoomClasses_Load(null, null);
        }

        private void frmListRoomClasses_Load(object sender, EventArgs e)
        {
            _dtAllRoomClasses = clsRoomClass.GetAllRoomClasses();
            dgvListRoomClasses.DataSource = _dtAllRoomClasses;
            lblRecordsCount.Text = dgvListRoomClasses.Rows.Count.ToString();

            if (dgvListRoomClasses.Rows.Count > 0)
            {
                dgvListRoomClasses.Columns["RoomClassID"].HeaderText = "ID";
                dgvListRoomClasses.Columns["RoomClassID"].Width = 90;


                dgvListRoomClasses.Columns["RoomClassName"].HeaderText = "Name";
                dgvListRoomClasses.Columns["RoomClassName"].Width = 120;

                dgvListRoomClasses.Columns["BasePrice"].HeaderText = "Price";
                dgvListRoomClasses.Columns["BasePrice"].Width = 100;

                dgvListRoomClasses.Columns["NumberOfBedTypes"].HeaderText = "Number Of BedTypes";
                dgvListRoomClasses.Columns["NumberOfBedTypes"].Width = 100;

                dgvListRoomClasses.Columns["NumberOfFeatures"].HeaderText = "Number Of Features";
                dgvListRoomClasses.Columns["NumberOfFeatures"].Width = 100;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditRoomClass frm = new frmAddEditRoomClass();
            frm.ShowDialog();
            frmListRoomClasses_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassID = (int)dgvListRoomClasses.CurrentRow.Cells[0].Value;
            frmAddEditRoomClass frm = new frmAddEditRoomClass(RoomClassID);
            frm.ShowDialog();
            frmListRoomClasses_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassID = (int)dgvListRoomClasses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Room Class [" + RoomClassID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsRoomClass.DeleteRoomClass(RoomClassID))
            {
                MessageBox.Show("Room Class Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListRoomClasses_Load(null, null);
            }
            else
            {
                MessageBox.Show("Room Class Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void showBedTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassID = (int)dgvListRoomClasses.CurrentRow.Cells[0].Value;
            frmShowListBedTypesForRoomClass frm = new frmShowListBedTypesForRoomClass(RoomClassID);
            frm.ShowDialog();
        }

        private void showFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassID = (int)dgvListRoomClasses.CurrentRow.Cells[0].Value;
            frmShowListFeaturesForRoomClass frm = new frmShowListFeaturesForRoomClass(RoomClassID);
            frm.ShowDialog();
        }
    }
}
