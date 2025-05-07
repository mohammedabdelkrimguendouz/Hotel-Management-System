using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        [HttpGet("GetAllBookings", Name = "GetAllBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookingsListDTO>> GetAllBookings()
        {
            List<BookingsListDTO> BookingsList = clsBooking.GetAllBookings();

            if (BookingsList.Count == 0)
                return NotFound("Not  Bookings Found !");

            return Ok(BookingsList);
        }


        [HttpGet("GetAllBookingsForPageNumber/{PageNumber}", Name = "GetAllBookingsForPageNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookingsListDTO>> GetAllBookingsForPageNumber(int PageNumber)
        {
            if (!clsValidation.ValidateInteger(Convert.ToString(PageNumber)))
                return BadRequest("Invalide Page Number " + PageNumber);

            List<BookingsListDTO> BookingsList = clsBooking.GetAllBookingsForPageNumber(PageNumber);

            if (BookingsList.Count == 0)
                return NotFound("Not  Bookings Found !");

            return Ok(BookingsList);
        }



        [HttpGet("GetBookingByID/{BookingID}", Name = "GetBookingByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingDTO> GetBookingByID(int BookingID)
        {
            if (BookingID < 1)
                return BadRequest("Not Accepted ID : " + BookingID);

            clsBooking Booking = clsBooking.Find(BookingID);

            if (Booking == null)
                return NotFound("Booking With ID : " + BookingID + " Not Found !");

            return Ok(Booking.bookingDTO);

        }


        [HttpDelete("DeleteBooking/{BookingID}", Name = "DeleteBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteBooking(int BookingID)
        {
            if (BookingID < 1)
                return BadRequest("Not Accepted ID : " + BookingID);

            if (!clsBooking.IsBookingExist(BookingID))
                return NotFound("Booking with id : " + BookingID + " Not Found !");

            if (!clsBooking.DeleteBooking(BookingID))
                return StatusCode(500, "Error delete Booking");


            return Ok("Booking with id : " + BookingID + " has been deleted");


        }


        [HttpGet("IsBookingExistByID/{BookingID}", Name = "IsBookingExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsBookingExistByID(int BookingID)
        {
            if (BookingID < 1)
                return BadRequest("Not Accepted ID : " + BookingID);



            return Ok(clsBooking.IsBookingExist(BookingID));
        }


        [HttpGet("DeosExistBookingActiveForGuest/{GuestID}", Name = "DeosExistBookingActiveForGuest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeosExistBookingActiveForGuest(int GuestID)
        {
            if (GuestID < 1)
                return BadRequest("Not Accepted ID : " + GuestID);

            if (!clsGuest.IsGuestExistByGuestID(GuestID))
                return NotFound("Guest With ID " + GuestID + " Not Found");


            return Ok(clsBooking.DeosExistBookingActiveForGuest(GuestID));
        }



        [HttpGet("CalculateDiscount/{LoyaltyPoints},{Amount}", Name = "CalculateDiscount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<float> CalculateDiscount(int LoyaltyPoints,float Amount)
        {
            return Ok(clsBooking.CalculateDiscount(LoyaltyPoints,Amount));

        }


        [HttpPut("SetCancelBooking/{BookingID}", Name = "SetCancelBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO> SetCancelBooking(int BookingID)
        {
            if (BookingID < 1)
                return BadRequest("Not Accept ID "+BookingID);

            clsBooking booking=clsBooking.Find(BookingID);

            if (booking == null)
                return NotFound("booking With ID : " + BookingID + " Not Found !");

            if(booking.BookingStatus==(byte)clsBooking.enBookingStatus.Cancelled)
                return  BadRequest("Booking Status Already Canclled ");


            if (!booking.SetCancel())
                return StatusCode(500, "Error Canclled Booking");


            return Ok(booking.bookingDTO);

        }


        [HttpDelete("UpdateBookingStatusIfCompleted/{BookingID}", Name = "UpdateBookingStatusIfCompleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateAllBookingStatusIfCompleted()
        {
            
            if (!clsBooking.UpdateAllBookingStatusIfCompleted())
                return StatusCode(500, "Error Update All Booking Status If Completed");


            return Ok("Update All Booking Status If Completed Successfully");


        }


        [HttpPost("AddBooking", Name = "AddBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BookingDTO> AddBooking(BookingDTO NewBookingDTO)
        {
            if (NewBookingDTO == null || NewBookingDTO.GuestID<1 || NewBookingDTO.PaymentID<1||
                NewBookingDTO.CreatedByEmployeeID<1)
                return BadRequest("Invalid Booking Data !");


            clsGuest guest = clsGuest.FindByGuestID(NewBookingDTO.GuestID);
            if (guest==null)
                return NotFound("Guest With ID " + NewBookingDTO.GuestID + " Not Found");

            if (!clsPayment.IsPaymentExist(NewBookingDTO.PaymentID))
                return NotFound("Payment with id : " + NewBookingDTO.PaymentID + " Not Found !");

            if (!clsEmployee.IsEmployeeExist(NewBookingDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + NewBookingDTO.CreatedByEmployeeID + " NotFound");



            float Discount = clsBooking.CalculateDiscount(guest.LoyaltyPoints, NewBookingDTO.BookingAmount);


            clsBooking Booking = new clsBooking(new BookingDTO(-1,NewBookingDTO.GuestID,NewBookingDTO.PaymentID,
                (byte)clsBooking.enBookingStatus.Pending,NewBookingDTO.CheckInDate,NewBookingDTO.CheckOutDate,
                NewBookingDTO.NumberAdults,NewBookingDTO.NumberChildren,NewBookingDTO.BookingAmount,
                Discount,NewBookingDTO.CreatedByEmployeeID));

            if (!Booking.Save())
                return StatusCode(500, "Error Add Booking");

            NewBookingDTO.BookingID = Booking.BookingID;


            return CreatedAtRoute("GetBookingByID", new { BookingID = NewBookingDTO.BookingID }, NewBookingDTO);


        }


        [HttpPut("UpdateBooking/{BookingID}", Name = "UpdateBooking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO> UpdateBooking(int BookingID, BookingDTO UpdatedBookingDTO)
        {
            if (UpdatedBookingDTO == null||BookingID<1 || UpdatedBookingDTO.GuestID < 1 || UpdatedBookingDTO.PaymentID < 1 ||
                 UpdatedBookingDTO.CreatedByEmployeeID < 1)
                return BadRequest("Invalid Booking Data !");

            clsBooking Booking = clsBooking.Find(BookingID);

            if (Booking == null)
                return NotFound("Booking With ID : " + BookingID + " Not Found !");

            clsGuest guest = clsGuest.FindByGuestID(UpdatedBookingDTO.GuestID);
            if (guest == null)
                return NotFound("Guest With ID " + UpdatedBookingDTO.GuestID + " Not Found");


            if (Booking.PaymentID!=UpdatedBookingDTO.PaymentID&& !clsPayment.IsPaymentExist(UpdatedBookingDTO.PaymentID))
                return NotFound("Payment with id : " + UpdatedBookingDTO.PaymentID + " Not Found !");

            if (Booking.CreatedByEmployeeID!=UpdatedBookingDTO.CreatedByEmployeeID&& !clsEmployee.IsEmployeeExist(UpdatedBookingDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + UpdatedBookingDTO.CreatedByEmployeeID + " NotFound");



            float Discount = clsBooking.CalculateDiscount(guest.LoyaltyPoints, UpdatedBookingDTO.BookingAmount);

           
            Booking.GuestID = UpdatedBookingDTO.GuestID;
            Booking.NumberChildren=UpdatedBookingDTO.NumberChildren;
            Booking.NumberAdults=UpdatedBookingDTO.NumberAdults;
            Booking.BookingAmount=UpdatedBookingDTO.BookingAmount;
            Booking.CreatedByEmployeeID=UpdatedBookingDTO.CreatedByEmployeeID;
            Booking.BookingStatus=(byte)clsBooking.enBookingStatus.Pending;
            Booking.CheckInDate=UpdatedBookingDTO.CheckInDate;
            Booking.CheckOutDate=UpdatedBookingDTO.CheckOutDate;
            Booking.PaymentID=UpdatedBookingDTO.PaymentID;
            Booking.Discount=Discount;


            if (!Booking.Save())
                return StatusCode(500, "Error Updating Booking");



            return Ok(Booking.bookingDTO);

        }

    }
}
