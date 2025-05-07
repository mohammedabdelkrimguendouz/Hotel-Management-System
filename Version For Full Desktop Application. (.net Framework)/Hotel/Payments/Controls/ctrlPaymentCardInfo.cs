using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Hotel.Properties;
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
//using static DVLD_Buisness.clsPayment;

namespace Hotel.Payments
{
    public partial class ctrlPaymentCardInfo : UserControl
    {
        private int _PaymentID = -1;
        public int PaymentID { get { return _PaymentID; } }

        private clsPayment _Payment;
        public clsPayment SelectedPaymentInfo { get { return _Payment; } }
        public ctrlPaymentCardInfo()
        {
            InitializeComponent();
        }
        public void LoadPaymentInfo(int PaymentID)
        {
            _Payment = clsPayment.Find(PaymentID);
            if (_Payment == null)
            {
                ResetPaymentInfo();
                MessageBox.Show("No Payment With ID = " + PaymentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPaymentInfo();

        }
        private void _FillPaymentInfo()
        {
            _PaymentID = _Payment.PaymentID;
            lblPaymentID.Text = _Payment.PaymentID.ToString();
            lblPaymentDate.Text = _Payment.PaymentDate.ToString() ;
            lblPaymentAmount.Text = _Payment.PaymentAmount.ToString();
            lblNotes.Text = _Payment.Notes;
            lblCreatedByEmplyoee.Text = _Payment.CreatedByEmployeeInfo.UserName;

            lblPaymentMothode.Text = _Payment.PaymentMethod.ToString();
            pbPaymentMothode.Image = (_Payment.PaymentMethod == clsPayment.enPaymentMethod.Cash) ? Resources.payment_cash_32 : Resources.payment_credit_card_32;
        }
        

        public void ResetPaymentInfo()
        {
            lblPaymentMothode.Text = "[????]";
            lblPaymentID.Text = "[????]";
            lblPaymentDate.Text = "[????]";
            lblPaymentAmount.Text = "[????]";
            lblNotes.Text = "[????]";
            lblCreatedByEmplyoee.Text = "[????]";
            _PaymentID = -1;
        }

       

       
    }
}
