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

namespace Hotel.RoomClassBedTypes
{
    public partial class frmShowListBedTypesForRoomClass : Form
    {
        private int _RoomClassID = -1;
        private clsRoomClass _RoomClass;
        private static DataTable _dtAllFeaturesForRoomClass;
        public frmShowListBedTypesForRoomClass(int RoomClassID)
        {
            InitializeComponent();
            _RoomClassID = RoomClassID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefrechListBedTypesForRoomClass()
        {
            _dtAllFeaturesForRoomClass = clsRoomClassBedType.GetAllBedTypesForRoomClass(_RoomClassID);

            dgvListBedTypesForRoomClass.DataSource = _dtAllFeaturesForRoomClass;
            lblRecordsCount.Text = dgvListBedTypesForRoomClass.Rows.Count.ToString();

            if (dgvListBedTypesForRoomClass.Rows.Count > 0)
            {
                
                dgvListBedTypesForRoomClass.Columns["RoomClassBedTypeID"].HeaderText = "Room Class Bed Type ID";
                dgvListBedTypesForRoomClass.Columns["RoomClassBedTypeID"].Width = 120;

                dgvListBedTypesForRoomClass.Columns["BedTypeID"].HeaderText = "Bed Type ID";
                dgvListBedTypesForRoomClass.Columns["BedTypeID"].Width = 90;


                dgvListBedTypesForRoomClass.Columns["BedTypeName"].HeaderText = "Bed Type Name";
                dgvListBedTypesForRoomClass.Columns["BedTypeName"].Width = 150;

                dgvListBedTypesForRoomClass.Columns["BedsNumber"].HeaderText = "Beds Number";
                //dgvListBedTypesForRoomClass.Columns["Description"].Width = 150;
            }
        }
        private void frmShowListBedTypesForRoomClass_Load(object sender, EventArgs e)
        {
            _RoomClass = clsRoomClass.Find(_RoomClassID);
            if (_RoomClass==null)
            {
                MessageBox.Show("No Room class With ID = " + _RoomClassID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddEditRoomClassBedTypes.Enabled = false;
                dgvListBedTypesForRoomClass.Enabled = false;
                return;
            }
            lblClassName.Text = _RoomClass.RoomClassName;
            _RefrechListBedTypesForRoomClass();
            
        }

        private void btnAddEditRoomClassBedTypes_Click(object sender, EventArgs e)
        {
            frmAddEditRoomClassBedTypes frm = new frmAddEditRoomClassBedTypes(_RoomClassID);
            frm.ShowDialog();
            _RefrechListBedTypesForRoomClass();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditRoomClassBedTypes frm = new frmAddEditRoomClassBedTypes(_RoomClassID);
            frm.ShowDialog();
            _RefrechListBedTypesForRoomClass();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassBedTypeID = (int) dgvListBedTypesForRoomClass.CurrentRow.Cells[0].Value;
            frmAddEditRoomClassBedTypes frm = new frmAddEditRoomClassBedTypes(_RoomClassID,RoomClassBedTypeID);
            frm.ShowDialog();
            _RefrechListBedTypesForRoomClass();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomClassBedTypeID = (int)dgvListBedTypesForRoomClass.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Room Class Bed Type [" + RoomClassBedTypeID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsRoomClassBedType.DeleteRoomClassBedType(RoomClassBedTypeID))
            {
                MessageBox.Show(" Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                _RefrechListBedTypesForRoomClass();
            }
            else
            {
                MessageBox.Show("Error  deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
