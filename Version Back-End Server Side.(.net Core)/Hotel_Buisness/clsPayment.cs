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

        public PaymentDTO paymentDTO
        {
            get => new PaymentDTO(this.PaymentID, this.PaymentAmount, this.PaymentDate, this.PaymentMethod,
                this.Notes, this.CreatedByEmployeeID);
        }
             

        public enMode Mode = enMode.AddNew;
        public int PaymentID { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public byte PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int CreatedByEmployeeID { get; set; }
        public clsEmployee CreatedByEmployeeInfo;
        public clsPayment(PaymentDTO paymentDTO,enMode CreationMode=enMode.AddNew)
        {
            this.PaymentID = paymentDTO.PaymentID;
            this.PaymentAmount = paymentDTO.PaymentAmount;
            this.PaymentDate = paymentDTO.PaymentDate;
            this.PaymentMethod = paymentDTO.PaymentMethod;
            this.Notes = paymentDTO.Notes;
            this.CreatedByEmployeeID = paymentDTO.CreatedByEmployeeID;
            this.CreatedByEmployeeInfo = clsEmployee.FindByEmployeeID(CreatedByEmployeeID);
            Mode = CreationMode;
        }

        public static clsPayment Find(int PaymentID)
        {

            PaymentDTO paymentDTO = clsPaymentData.GetPaymentInfoByID(PaymentID);

            if (paymentDTO!=null)
            {
                return new clsPayment(paymentDTO,enMode.Update);

            }
            return null;

        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(paymentDTO);
            return (this.PaymentID != -1);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(paymentDTO);
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

        public static List<PaymentsListDTO> GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }
        public static List<PaymentsListDTO> GetAllPaymentsForPageNumber(int PageNumber)
        {
            return clsPaymentData.GetAllPaymentsForPageNumber(PageNumber);
        }

        public static bool IsPaymentExist(int PaymentID)
        {
            return clsPaymentData.IsPaymentExist(PaymentID);
        }
    }
}
