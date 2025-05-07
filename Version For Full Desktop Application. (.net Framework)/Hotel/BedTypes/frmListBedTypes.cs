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

namespace Hotel.BedTypes
{
    public partial class frmListBedTypes : Form
    {
        private static DataTable _dtAllBedTypes;
        public frmListBedTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEditBedType_Click(object sender, EventArgs e)
        {
            frmAddEditBedType frm = new frmAddEditBedType();
            frm.ShowDialog();
            frmListBedTypes_Load(null, null);
        }

        private void frmListBedTypes_Load(object sender, EventArgs e)
        {
            _dtAllBedTypes = clsBedType.GetAllBedTypes();
            dgvListBedTypes.DataSource = _dtAllBedTypes;
            lblRecordsCount.Text = dgvListBedTypes.Rows.Count.ToString();

            if (dgvListBedTypes.Rows.Count > 0)
            {
                dgvListBedTypes.Columns["BedTypeID"].HeaderText = "ID";
                dgvListBedTypes.Columns["BedTypeID"].Width = 60;


                dgvListBedTypes.Columns["BedTypeName"].HeaderText = "Name";
                dgvListBedTypes.Columns["BedTypeName"].Width = 95;

                dgvListBedTypes.Columns["Description"].HeaderText = "Description";
                //dgvListBedTypes.Columns["Description"].Width = 150;
            }
        }

       

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int BedTypeID = (int)dgvListBedTypes.CurrentRow.Cells[0].Value;
            frmAddEditBedType frm = new frmAddEditBedType(BedTypeID);
            frm.ShowDialog();
            frmListBedTypes_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int BedTypeID = (int)dgvListBedTypes.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete BedType [" + BedTypeID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (clsBedType.DeleteBedType(BedTypeID))
            {
                MessageBox.Show("BedType Deleted Successfully", "Successful", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                frmListBedTypes_Load(null, null);
            }
            else
            {
                MessageBox.Show("BedType Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditBedType frm = new frmAddEditBedType();
            frm.ShowDialog();
            frmListBedTypes_Load(null, null);
        }
    }
}
