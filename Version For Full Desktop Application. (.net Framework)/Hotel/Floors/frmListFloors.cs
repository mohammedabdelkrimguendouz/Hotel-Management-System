using Hotel_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hotel.Floors
{
    public partial class frmListFloors : Form
    {
        private static DataTable _dtAllFloors;
        public frmListFloors()
        {
            InitializeComponent();
        }

        private void frmListFloors_Load(object sender, EventArgs e)
        {
            _dtAllFloors = clsFloor.GetAllFloors();
            dgvListFloors.DataSource = _dtAllFloors;
            lblRecordsCount.Text = dgvListFloors.Rows.Count.ToString();

            if (dgvListFloors.Rows.Count > 0)
            {
                dgvListFloors.Columns["FloorID"].HeaderText = "ID";
                dgvListFloors.Columns["FloorID"].Width = 90;


                dgvListFloors.Columns["FloorNumber"].HeaderText = "Floor Number";
                dgvListFloors.Columns["FloorNumber"].Width = 90;

                dgvListFloors.Columns["FloorArea"].HeaderText = "Area";
                dgvListFloors.Columns["FloorArea"].Width = 120;

                dgvListFloors.Columns["NumberOfRooms"].HeaderText = "Number Of Rooms";
                dgvListFloors.Columns["NumberOfRooms"].Width = 150;
            }
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditFloor frm = new frmAddEditFloor();
            frm.ShowDialog();
            frmListFloors_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int FloorID =(int) dgvListFloors.CurrentRow.Cells[0].Value;
            frmAddEditFloor frm = new frmAddEditFloor(FloorID);
            frm.ShowDialog();
            frmListFloors_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int FloorID = (int)dgvListFloors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Floor [" + FloorID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsFloor.DeleteFloor(FloorID))
            {
                MessageBox.Show("Floor Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListFloors_Load(null, null);
            }
            else
            {
                MessageBox.Show("Floor Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditFloor frm = new frmAddEditFloor();
            frm.ShowDialog();
            frmListFloors_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
