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

namespace Hotel.Rooms.Controls
{
    public partial class ctrlRoomCardInfoWithFilter : UserControl
    {

        public class RoomSelectedEventArgs : EventArgs
        {
            public int RoomID { get; }
            public RoomSelectedEventArgs(int RoomID)
            {
                this.RoomID = RoomID;
            }
        }

        public event EventHandler<RoomSelectedEventArgs> OnRoomSelected;

        public void RaiseOnRoomSelected(int RoomID)
        {
            RaiseOnRoomSelected(new RoomSelectedEventArgs(RoomID));
        }
        protected virtual void RaiseOnRoomSelected(RoomSelectedEventArgs e)
        {
            OnRoomSelected?.Invoke(this, e);
        }

        private bool _EnableFilter = true;
        public bool EnableFilter
        {
            get { return _EnableFilter; }
            set
            {
                _EnableFilter = value;
                gbFilters.Enabled = _EnableFilter;
            }
        }

        public int RoomID { get { return ctrlRoomCardInfo1.RoomID; } }

        public clsRoom SelectedRoomInfo { get { return ctrlRoomCardInfo1.SelectedRoomInfo; } }
        public ctrlRoomCardInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }


        public void LoadRoomInfoByRoomID(int RoomID)
        {
            cbFilters.SelectedIndex = cbFilters.FindString("Room ID");
            txtFilterValue.Text = RoomID.ToString();
            _FindNow();
        }

        public void LoadRoomInfoByRoomNumber(short RoomNumber)
        {
            cbFilters.SelectedIndex = cbFilters.FindString("Room Number");
            txtFilterValue.Text = RoomNumber.ToString();
            _FindNow();
        }

        private void _FindNow()
        {
            if (cbFilters.Text == "Room ID")
                ctrlRoomCardInfo1.LoadRoomInfoByID(Convert.ToInt32(txtFilterValue.Text.Trim()));
            else
                ctrlRoomCardInfo1.LoadRoomInfoByRoomNumber(short.Parse(txtFilterValue.Text.Trim()));

            if (OnRoomSelected != null && EnableFilter)
                RaiseOnRoomSelected(ctrlRoomCardInfo1.RoomID);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("filed is not valide!, put the mouse over the red icon to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }

        private void ctrlRoomCardInfoWithFilter_Load(object sender, EventArgs e)
        {
            ctrlRoomCardInfo1.ResetRoomInfo();
            cbFilters.SelectedIndex = 0;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
    }
}
