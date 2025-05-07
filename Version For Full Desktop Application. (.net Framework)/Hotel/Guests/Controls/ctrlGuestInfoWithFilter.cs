using Hotel.Guests;
using Hotel.Rooms;
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

namespace Hotel.Guests.Controls
{
    public partial class ctrlGuestInfoWithFilter : UserControl
    {
        public class GuestSelectedEventArgs : EventArgs
        {
            public int GuestID { get; }
            public GuestSelectedEventArgs(int GuestID)
            {
                this.GuestID = GuestID;
            }
        }

        public event EventHandler<GuestSelectedEventArgs> OnGuestSelected;

        public void RaiseOnGuestSelected(int GuestID)
        {
            RaiseOnGuestSelected(new GuestSelectedEventArgs(GuestID));
        }
        protected virtual void RaiseOnGuestSelected(GuestSelectedEventArgs e)
        {
            OnGuestSelected?.Invoke(this, e);
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

        private bool _EnableAddNew = true;
        public bool EnableAddNew
        {
            get { return _EnableAddNew; }
            set
            {
                _EnableAddNew = value;
                btnAddNew.Enabled = _EnableAddNew;
            }
        }

        public int GuestID { get { return ctrlGuestCardInfo1.GuestID; } }

        public clsGuest SelectedGuestInfo { get { return ctrlGuestCardInfo1.SelectedGuestInfo; } }
        public ctrlGuestInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();
            if(cbFilters.Text=="Guest ID")
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

        public void LoadGuestInfo(int GuestID)
        {
            cbFilters.SelectedIndex = cbFilters.FindString("Guest ID");
            txtFilterValue.Text = GuestID.ToString();
            _FindNow();
        }

        public void LoadGuestInfo(string NationalNo)
        {
            cbFilters.SelectedIndex = cbFilters.FindString("National No");
            txtFilterValue.Text = NationalNo;
            _FindNow();
        }

        private void _FindNow()
        {
            if (cbFilters.Text == "Guest ID")
                ctrlGuestCardInfo1.LoadGuestInfo(Convert.ToInt32(txtFilterValue.Text.Trim()));
            else
                ctrlGuestCardInfo1.LoadGuestInfo(txtFilterValue.Text.Trim());

            if (OnGuestSelected != null && EnableFilter)
                RaiseOnGuestSelected(ctrlGuestCardInfo1.GuestID);
        }

        private void ctrlGuestInfoWithFilter_Load(object sender, EventArgs e)
        {
            ctrlGuestCardInfo1.ResetGuestInfo();
            cbFilters.SelectedIndex = 0;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditGuest frm = new frmAddEditGuest();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void DataBackEvent(object sender, frmAddEditGuest.GuestEventArgs e)
        {
            LoadGuestInfo(e.NationalNo);
        }
    }
}
