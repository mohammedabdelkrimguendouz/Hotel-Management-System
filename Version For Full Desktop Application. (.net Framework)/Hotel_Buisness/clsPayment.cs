using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enum enPaymentMethod { Cash =0, CreditCard =1}

        public enMode Mode = enMode.AddNew;
        public int PaymentID { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public enPaymentMethod PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int CreatedByEmployeeID { get; set; }
        public clsEmployee CreatedByEmployeeInfo;
        private clsPayment(int PaymentID, float PaymentAmount, DateTime PaymentDate, enPaymentMethod PaymentMethod, string Notes, int CreatedByEmployeeID)
        {
            this.PaymentID = PaymentID;
            this.PaymentAmount = PaymentAmount;
            this.PaymentDate = PaymentDate;
            this.PaymentMethod = PaymentMethod;
            this.Notes = Notes;
            this.CreatedByEmployeeID = CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = enMode.Update;
        }

        public clsPayment()
        {
            PaymentID = -1;
            PaymentAmount = 0.0f;
            PaymentDate = DateTime.Now;
            PaymentMethod = enPaymentMethod.Cash;
            Notes = "";
            CreatedByEmployeeID = -1;
            Mode = enMode.AddNew;
        }

        public static clsPayment Find(int PaymentID)
        {

            float PaymentAmount = 0; DateTime PaymentDate = DateTime.Now; short PaymentMethod = 0; string Notes = ""; int CreatedByEmployeeID = -1;

            if (clsPaymentData.GetPaymentInfoByID( PaymentID, ref PaymentAmount, ref PaymentDate, ref PaymentMethod, ref Notes, ref CreatedByEmployeeID))
            {
                return new clsPayment(PaymentID, PaymentAmount, PaymentDate,(enPaymentMethod) PaymentMethod, Notes, CreatedByEmployeeID);

            }
            return null;

        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(PaymentAmount, PaymentDate, (short)PaymentMethod, Notes, CreatedByEmployeeID);
            return (this.PaymentID != -1);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(PaymentID, PaymentAmount, PaymentDate,(short) PaymentMethod, Notes, CreatedByEmployeeID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePayment();
            }
            return false;
        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }
        public static DataTable GetAllPaymentsForPageNumber(int PageNumber)
        {
            return clsPaymentData.GetAllPaymentsForPageNumber(PageNumber);
        }

        public static bool IsPaymentExist(int PaymentID)
        {
            return clsPaymentData.IsPaymentExist(PaymentID);
        }
    }
}
