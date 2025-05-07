using DVLD_Buisness;
using Hotel.BedTypes;
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
    public partial class frmAddEditRoomClassBedTypes : Form
    {
        public enum enMode { AddNew=0,Update=1 };
        private enMode _Mode;
        private int _RoomClassBedTypeID = -1;
        private int _RoomClassID = -1;
        private clsRoomClassBedType _RoomClassBedType;
        public frmAddEditRoomClassBedTypes(int RoomClassID,int RoomClassBedTypeID)
        {
            InitializeComponent();
            _RoomClassBedTypeID = RoomClassBedTypeID;
            _RoomClassID = RoomClassID;
            _Mode = enMode.Update;
        }
        public frmAddEditRoomClassBedTypes(int RoomClassID)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _RoomClassID = RoomClassID;
        }

        private void _FillBedTypesInCompoBox()
        {
            DataTable dt = clsBedType.GetAllBedTypes();
            foreach (DataRow Row in dt.Rows)
            {
                cbBedTypes.Items.Add(Row["BedTypeName"]);
            }
            if (cbBedTypes.Items.Count >= 0)
                cbBedTypes.SelectedIndex = 0;
        }
        private void _ResetDefaultValues()
        {
            _FillBedTypesInCompoBox();
            if (_Mode == enMode.AddNew)
            {
                this.Text = lblTitle.Text = "Add Room Class Bed Type";
                _RoomClassBedType = new clsRoomClassBedType();
            }
            else
            {
                this.Text = lblTitle.Text = "Edit Room Class Bed Type";
            }
            nudBedsNumber.Value = 0;
            lblRoomClassBedTypeID.Text = "[????]";
        }
        private void _LoadData()
        {
            _RoomClassBedType = clsRoomClassBedType.Find(_RoomClassBedTypeID);
            if (_RoomClassBedType == null)
            {
                MessageBox.Show("this form well be closed because No _Room Class Bed Type With ID : " + _RoomClassBedTypeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblRoomClassBedTypeID.Text = _RoomClassBedType.RoomClassBedTypeID.ToString();
            cbBedTypes.SelectedIndex = cbBedTypes.FindString(_RoomClassBedType.BedTypeInfo.BedTypeName);
            cbBedTypes.Enabled = false;
            btnAddEditBedType.Enabled = false;
            nudBedsNumber.Value = _RoomClassBedType.BedsNumber;
        }
        private void frmAddEditRoomClassBedTypes_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int BedTypeID = clsBedType.Find(cbBedTypes.Text.Trim()).BedTypeID;
            if (clsRoomClassBedType.IsRoomClassBedTypeExistByBedTypeAndRoomClass(BedTypeID,_RoomClassID))
            {
                MessageBox.Show("this Bed Type already exist in this room class", " Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _RoomClassBedType.BedsNumber =(short) nudBedsNumber.Value;
            _RoomClassBedType.BedTypeID = BedTypeID;
            _RoomClassBedType.RoomClassID = _RoomClassID;
            if (_RoomClassBedType.Save())
            {

                this.Text = lblTitle.Text = "Edit Room Class Bed Type";
                _Mode = enMode.Update;
                lblRoomClassBedTypeID.Text = _RoomClassBedType.RoomClassBedTypeID.ToString();

                MessageBox.Show("Data Saved Successfully ", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Data is not Saved Successfully ", "Error ",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddEditBedType_Click(object sender, EventArgs e)
        {
            frmAddEditBedType frm = new frmAddEditBedType();
            frm.ShowDialog();
            _FillBedTypesInCompoBox();
        }
    }
}
