using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpGet("GetAllPayments", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PaymentsListDTO>> GetAllPayments()
        {
            List<PaymentsListDTO> PaymentsList = clsPayment.GetAllPayments();

            if (PaymentsList.Count == 0)
                return NotFound("Not  Payments Found !");

            return Ok(PaymentsList);
        }


        [HttpGet("GetAllPaymentsForPageNumber/{PageNumber}", Name = "GetAllPaymentsForPageNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<PaymentsListDTO>> GetAllPaymentsForPageNumber(int PageNumber)
        {
            if (!clsValidation.ValidateInteger(Convert.ToString(PageNumber)))
                return BadRequest("Invalide Page Number " + PageNumber);

            List<PaymentsListDTO> PaymentsList = clsPayment.GetAllPaymentsForPageNumber(PageNumber);

            if (PaymentsList.Count == 0)
                return NotFound("Not  Payments Found !");

            return Ok(PaymentsList);
        }

        [HttpGet("IsPaymentExistByID/{PaymentID}", Name = "IsPaymentExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsPaymentExistByID(int PaymentID)
        {
            if (PaymentID < 1)
                return BadRequest("Not Accepted ID : " + PaymentID);



            return Ok(clsPayment.IsPaymentExist(PaymentID));
        }

        [HttpDelete("DeletePayment/{PaymentID}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletePayment(int PaymentID)
        {
            if (PaymentID < 1)
                return BadRequest("Not Accepted ID : " + PaymentID);

            if (!clsPayment.IsPaymentExist(PaymentID))
                return NotFound("Payment with id : " + PaymentID + " Not Found !");

            if (!clsPayment.DeletePayment(PaymentID))
                return StatusCode(500, "Error delete Payment");


            return Ok("Payment with id : " + PaymentID + " has been deleted");


        }


        [HttpGet("GetPaymentByID/{PaymentID}", Name = "GetPaymentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PaymentDTO> GetPaymentByID(int PaymentID)
        {
            if (PaymentID < 1)
                return BadRequest("Not Accepted ID : " + PaymentID);

            clsPayment Payment = clsPayment.Find(PaymentID);

            if (Payment == null)
                return NotFound("Payment With ID : " + PaymentID + " Not Found !");

            return Ok(Payment.paymentDTO);

        }

        [HttpPost("AddPayment", Name = "AddPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PaymentDTO> AddPayment(PaymentDTO NewPaymentDTO,clsPayment.enPaymentMethod PaymentMethod)
        {
            if (NewPaymentDTO == null || !clsValidation.IsNumber(Convert.ToString(NewPaymentDTO.PaymentAmount))||
                NewPaymentDTO.CreatedByEmployeeID<1)
                return BadRequest("Invalid Payment Data !");

            if (!clsEmployee.IsEmployeeExist(NewPaymentDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + NewPaymentDTO.CreatedByEmployeeID + " NotFound");



            clsPayment Payment = new clsPayment(new PaymentDTO(-1,NewPaymentDTO.PaymentAmount,NewPaymentDTO.PaymentDate,
                (byte)PaymentMethod,NewPaymentDTO.Notes,NewPaymentDTO.CreatedByEmployeeID));

            if (!Payment.Save())
                return StatusCode(500, "Error Add Payment");

            NewPaymentDTO.PaymentID = Payment.PaymentID;


            return CreatedAtRoute("GetPaymentByID", new { PaymentID = NewPaymentDTO.PaymentID }, NewPaymentDTO);


        }


        [HttpPut("UpdatePayment/{PaymentID}", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PaymentDTO> UpdatePayment(int PaymentID, PaymentDTO UpdatedPaymentDTO,clsPayment.enPaymentMethod PaymentMethod)
        {
            if (UpdatedPaymentDTO == null || !clsValidation.IsNumber(Convert.ToString(UpdatedPaymentDTO.PaymentAmount)) ||
                 UpdatedPaymentDTO.CreatedByEmployeeID < 1)
                return BadRequest("Invalid Payment Data !");

            clsPayment Payment = clsPayment.Find(PaymentID);

            if (Payment == null)
                return NotFound("Payment With ID : " + PaymentID + " Not Found !");


            if (Payment.CreatedByEmployeeID!=UpdatedPaymentDTO.CreatedByEmployeeID&&!clsEmployee.IsEmployeeExist(UpdatedPaymentDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + UpdatedPaymentDTO.CreatedByEmployeeID + " NotFound");

           

            Payment.PaymentAmount = UpdatedPaymentDTO.PaymentAmount;
            Payment.PaymentDate = UpdatedPaymentDTO.PaymentDate;
            Payment.PaymentMethod = (byte)PaymentMethod;
            Payment.Notes = UpdatedPaymentDTO.Notes;
            Payment.CreatedByEmployeeID=UpdatedPaymentDTO.CreatedByEmployeeID;


            if (!Payment.Save())
                return StatusCode(500, "Error Updating Payment");



            return Ok(Payment.paymentDTO);

        }




    }
}
