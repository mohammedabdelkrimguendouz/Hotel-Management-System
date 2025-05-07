using Hotel.Guests;
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

namespace Hotel.Payments
{
    public partial class frmListPayments : Form
    {
        private static DataTable _dtAllPayments;
        private int _PageNumber = 1;

        private enum enAfterChangePage { AfterLoad = 0, AfterNext = 1, AfterPrev = 2, AfterAdd = 3, AfterDelete = 4 }
        private enAfterChangePage _AfterChangePage = enAfterChangePage.AfterLoad;
        public frmListPayments()
        {
            InitializeComponent();
        }

        private void _HandelPages()
        {
            switch (_AfterChangePage)
            {
                case enAfterChangePage.AfterLoad:
                    _PageNumber = 1;
                    btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    _ReferchListPayments();
                    btnNext.Enabled = (clsPayment.GetAllPaymentsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterNext:
                    _PageNumber = _PageNumber + 1;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnPrev.Enabled = true;
                    _ReferchListPayments();
                    btnNext.Enabled = (clsPayment.GetAllPaymentsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterPrev:
                    _PageNumber -= 1;
                    if (_PageNumber == 1)
                        btnPrev.Enabled = false;
                    lblPageNumber.Text = _PageNumber.ToString();
                    btnNext.Enabled = true;
                    _ReferchListPayments();
                    break;
                case enAfterChangePage.AfterAdd:
                    btnNext.Enabled = (clsPayment.GetAllPaymentsForPageNumber(_PageNumber + 1)).Rows.Count > 0;
                    break;
                case enAfterChangePage.AfterDelete:
                    bool IsCurrentPageExist = (clsPayment.GetAllPaymentsForPageNumber(_PageNumber).Rows.Count) > 0;
                    if (!IsCurrentPageExist)
                    {
                        btnNext.Enabled = false;

                        if (_PageNumber != 1)
                        {
                            _PageNumber -= 1;
                            lblPageNumber.Text = _PageNumber.ToString();
                            _ReferchListPayments();
                        }
                        else
                            btnPrev.Enabled = false;

                    }
                    else
                    {
                        bool IsNextPageExist = (clsPayment.GetAllPaymentsForPageNumber(_PageNumber + 1)).Rows.Count > 0;

                        btnNext.Enabled = IsNextPageExist;
                        if (_PageNumber == 1)
                            btnPrev.Enabled = false;
                    }
                    break;
            }
        }

        private void _ReferchListPayments()
        {
            _dtAllPayments = clsPayment.GetAllPaymentsForPageNumber(_PageNumber);
            dgvListPayments.DataSource = _dtAllPayments;
            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();

            if (dgvListPayments.Rows.Count > 0)
            {
                dgvListPayments.Columns["PaymentID"].HeaderText = "Payment ID";
                dgvListPayments.Columns["PaymentID"].Width = 90;

                dgvListPayments.Columns["BookingID"].HeaderText = "Booking ID";
                dgvListPayments.Columns["BookingID"].Width = 90;

                dgvListPayments.Columns["NationalNo"].HeaderText = "National No";
                dgvListPayments.Columns["NationalNo"].Width = 140;

                dgvListPayments.Columns["FullName"].HeaderText = "Full Name";
                dgvListPayments.Columns["FullName"].Width = 150;


                dgvListPayments.Columns["PaymentAmount"].HeaderText = "Payment Amount";
                dgvListPayments.Columns["PaymentAmount"].Width = 100;


                dgvListPayments.Columns["PaymentDate"].HeaderText = "Payment Date";
                //dgvListRooms.Columns["NumberOfBookings"].Width = 90;
            }
            cbFilter.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListPayments_Load(object sender, EventArgs e)
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

        private void showDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dgvListPayments.CurrentRow.Cells[0].Value;
            frmShowPaymentInfo frm = new frmShowPaymentInfo(PaymentID);
            frm.ShowDialog();
            _ReferchListPayments();
        }

        private void txtfilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Payment ID" || cbFilter.Text == "Booking ID" )
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txtfilterValue.Visible = (cbFilter.Text != "None");
            if (txtfilterValue.Visible)
            {
                txtfilterValue.Text = "";
                txtfilterValue.Focus();
            }
            
                _dtAllPayments.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();
        }

        private void txtfilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Payment ID":
                    FilterColumn = "PaymentID";
                    break;
                case "Booking ID":
                    FilterColumn = "BookingID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
               
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
               
            }
            if (txtfilterValue.Text.Trim() == "")
                _dtAllPayments.DefaultView.RowFilter = "";
            else if (FilterColumn == "PaymentID" || FilterColumn == "BookingID" )
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilterValue.Text.Trim());
            else
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtfilterValue.Text.Trim());
            lblRecordsCount.Text = dgvListPayments.Rows.Count.ToString();
        }

        
    }
}
