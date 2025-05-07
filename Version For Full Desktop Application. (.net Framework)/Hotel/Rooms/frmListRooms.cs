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

namespace Hotel.Rooms
{
    public partial class frmListRooms : Form
    {
        private static DataTable _dtAllRooms;
        private int _PageNumber = 1;

        private enum enAfterChangePage {AfterLoad=0,AfterNext=1,AfterPrev=2,AfterAdd=3,AfterDelete=4}
        private enAfterChangePage _AfterChangePage=enAfterChangePage.AfterLoad;
        public frmListRooms()
        {
            InitializeComponent();
        }

        private void _FillFloorNumbersInCompoBox()
        {
            DataTable dt = clsFloor.GetAllFloors();
            foreach (DataRow Row in dt.Rows)
            {
                cbFilterValue.Items.Add(Row["FloorNumber"]);
            }
            if (cbFilterValue.Items.Count >= 0)
                cbFilterValue.SelectedIndex = 0;
        }
        private void _FillRoomClassesInCompoBox()
        {
            DataTable dt = clsRoomClass.GetAllRoomClasses();
            foreach (DataRow Row in dt.Rows)
            {
                cbFilterValue.Items.Add(Row["RoomClassName"]);
            }
            if (cbFilterValue.Items.Count >= 0)
                cbFilterValue.SelectedIndex = 0;
        }

        private void addNewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditRoom frm = new frmAddEditRoom();
            frm.ShowDialog();
            _ReferchListRooms();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditRoom frm = new frmAddEditRoom();
            frm.ShowDialog();
            _ReferchListRooms();
            _AfterChangePage = enAfterChangePage.AfterAdd;
            _HandelPages();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvListRooms.CurrentRow.Cells[0].Value;
            frmAddEditRoom frm = new frmAddEditRoom(RoomID);
            frm.ShowDialog();
            _ReferchListRooms();
        }

        private void showDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvListRooms.CurrentRow.Cells[0].Value;
            frmShowRoomInfo frm = new frmShowRoomInfo(RoomID);
            frm.ShowDialog();
            _ReferchListRooms();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomID = (int)dgvListRooms.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure do you want to delete Room [" + RoomID + "]", "Confirm Delete", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            if (!clsRoom.DeleteRoom(RoomID))
            {
                MessageBox.Show("Room Was not deleted because it has data linked to it", "Error Delete", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Room Deleted Successfully", "Successful", MessageBoxButtons.OK,
               MessageBoxIcon.Information);

            _ReferchListRooms();

            _AfterChangePage = enAfterChangePage.AfterDelete;
            _HandelPages();

            
               
        }

        private void _ReferchListRooms()
        {
            _dtAllRooms = clsRoom.GetAllRoomsForPageNumber(_PageNumber);
            dgvListRooms.DataSource = _dtAllRooms;
            lblRecordsCount.Text = dgvListRooms.Rows.Count.ToString();
           
            if (dgvListRooms.Rows.Count > 0)
            {
                dgvListRooms.Columns["RoomID"].HeaderText = "Room ID";
                dgvListRooms.Columns["RoomID"].Width = 70;

                dgvListRooms.Columns["RoomNumber"].HeaderText = "Room Number";
                dgvListRooms.Columns["RoomNumber"].Width = 100;

                dgvListRooms.Columns["RoomClassName"].HeaderText = "Class Name";
                dgvListRooms.Columns["RoomClassName"].Width = 140;

                

                

                dgvListRooms.Columns["FloorNumber"].HeaderText = "Floor Number";
                dgvListRooms.Columns["FloorNumber"].Width = 90;

                dgvListRooms.Columns["Available"].HeaderText = "Available";
                dgvListRooms.Columns["Available"].Width = 70;
            }
            cbFilter.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }

        private void frmListRooms_Load(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterLoad;
            _HandelPages();
        }

        
        private void btnNext_Click(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterNext;
            _HandelPages();
            
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _AfterChangePage = enAfterChangePage.AfterPrev;
            _HandelPages();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {


            cbAvailable.Visible = (cbFilter.Text == "Available");
            if (cbAvailable.Visible)
                cbAvailable.SelectedIndex = 0;

            txtfilterValue.Visible = (cbFilter.Text == "Room ID") || (cbFilter.Text == "Room Number");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }

            cbFilterValue.Visible = ((!cbAvailable.Visible) && (!txtfilterValue.Visible)&&(cbFilter.Text!="None" ));

            if (cbFilterValue.Visible)
            {

                cbFilterValue.Items.Clear();
                cbFilterValue.Items.Add("None");

                switch(cbFilter.Text)
                {
                    case "Class Name":
                        _FillRoomClassesInCompoBox(); 
                        break;
                    case "Floor Number":
                        _FillFloorNumbersInCompoBox();
                        break;
                }
                
            }

            _dtAllRooms.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListRooms.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Room ID":
                    FilterColumn = "RoomID";
                    break;
                case "Room Number":
                    FilterColumn = "RoomNumber";
                    break;
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllRooms.DefaultView.RowFilter = "";
            else
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
           
            lblRecordsCount.Text = dgvListRooms.Rows.Count.ToString();
        }

        private void cbAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterIColumn = "Available";
            string FilterValue = "";
            switch (cbAvailable.Text)
            {
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (cbAvailable.Text == "All")
                _dtAllRooms.DefaultView.RowFilter = "";
            else
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterIColumn, FilterValue);
            lblRecordsCount.Text = dgvListRooms.Rows.Count.ToString();
        }

        private void cbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
      
            switch(cbFilter.Text)
            {
                case "Class Name":
                    FilterColumn = "RoomClassName";
                    break;
                case "Floor Number":
                    FilterColumn = "FloorNumber";
                    break;
            }
            if (cbFilterValue.Text == "None")
                _dtAllRooms.DefaultView.RowFilter = "";
            else
                _dtAllRooms.DefaultView.RowFilter = string.Format("[{0}]='{1}'", FilterColumn, cbFilterValue.Text);
            lblRecordsCount.Text = dgvListRooms.Rows.Count.ToString();
        }

        private void _HandelPages()
        {
            switch(_AfterChangePage) 
            {
                case enAfterChangePage.AfterLoad:
                    _PageNumber = 1;
                    btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    _ReferchListRooms();
                    btnNext.Enabled = (clsRoom.GetAllRoomsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterNext:
                    _PageNumber = _PageNumber + 1;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnPrev.Enabled = true;
                    _ReferchListRooms();
                    btnNext.Enabled = (clsRoom.GetAllRoomsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterPrev:
                    _PageNumber -= 1;
                    if (_PageNumber == 1)
                        btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnNext.Enabled = true;
                    _ReferchListRooms();
                    break;
                case enAfterChangePage.AfterAdd:
                    btnNext.Enabled = (clsRoom.GetAllRoomsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterDelete:
                    bool IsCurrentPageExist = (clsRoom.GetAllRoomsForPageNumber(_PageNumber).Rows.Count) > 0;
                    if (!IsCurrentPageExist)
                    {
                        btnNext.Enabled = false;

                        if (_PageNumber != 1)
                        {
                            _PageNumber -= 1;
                            lblPageNumber.Text = _PageNumber.ToString();
                            _ReferchListRooms();
                        }
                        else
                            btnPrev.Enabled = false;

                    }
                    else
                    {
                        bool IsNextPageExist = (clsRoom.GetAllRoomsForPageNumber(_PageNumber + 1)).Rows.Count > 0;

                        btnNext.Enabled = IsNextPageExist;
                        if (_PageNumber == 1)
                            btnPrev.Enabled = false;
                    }
                    break;
            }
        }
    }
}
