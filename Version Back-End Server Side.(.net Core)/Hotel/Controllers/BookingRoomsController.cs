using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/BookingRooms")]
    [ApiController]
    public class BookingRoomsController : ControllerBase
    {
        [HttpGet("GetAllBookingRooms", Name = "GetAllBookingRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BookingRoomsListDTO>> GetAllBookingRooms()
        {
            List<BookingRoomsListDTO> BookingRoomsList = clsBookingRoom.GetAllBookingRooms();

            if (BookingRoomsList.Count == 0)
                return NotFound("Not  Booking Rooms Found !");

            return Ok(BookingRoomsList);
        }


        [HttpGet("GetAllRoomsForBookingID/{BookingID}", Name = "GetAllRoomsForBookingID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<RoomsForBookingsListDTO>> GetAllRoomsForBookingID(int BookingID)
        {
            if(BookingID<1)
                return BadRequest("Not Accept ID "+BookingID);

            if (!clsBooking.IsBookingExist(BookingID))
                return NotFound("Booking With id " + BookingID + " Not Found !");


            List<RoomsForBookingsListDTO> roomsForBookingsLists = clsBookingRoom.GetAllRoomsForBookingID(BookingID);

            if (roomsForBookingsLists.Count == 0)
                return NotFound("Not   Rooms For Booking with id "+BookingID);

            return Ok(roomsForBookingsLists);
        }


        [HttpGet("IsBookingRoomExistByID/{BookingRoomID}", Name = "IsBookingRoomExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsBookingRoomExistByID(int BookingRoomID)
        {
            if (BookingRoomID < 1)
                return BadRequest("Not Accepted ID : " + BookingRoomID);



            return Ok(clsBookingRoom.IsBookingRoomExist(BookingRoomID));
        }



        [HttpDelete("DeleteBookingRoom/{BookingRoomID}", Name = "DeleteBookingRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteBookingRoom(int BookingRoomID)
        {
            if (BookingRoomID < 1)
                return BadRequest("Not Accepted ID : " + BookingRoomID);

            if (!clsBookingRoom.IsBookingRoomExist(BookingRoomID))
                return NotFound("BookingRoom with id : " + BookingRoomID + " Not Found !");

            if (!clsBookingRoom.DeleteBookingRoom(BookingRoomID))
                return StatusCode(500, "Error delete BookingRoom");


            return Ok("BookingRoom with id : " + BookingRoomID + " has been deleted");


        }



        [HttpDelete("DeleteAllBookingRoomsForBookingID/{BookingID}", Name = "DeleteAllBookingRoomsForBookingID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteAllBookingRoomsForBookingID(int BookingID)
        {

            if (BookingID < 1)
                return BadRequest("Not Accept ID " + BookingID);

            if (!clsBooking.IsBookingExist(BookingID))
                return NotFound("Booking With id " + BookingID + " Not Found !");

           

            if (!clsBookingRoom.DeleteAllBookingRoomsForBookingID(BookingID))
                return StatusCode(500, "Error Delete All Booking Rooms For Booking ID "+BookingID);


            return Ok("Delete All Booking Rooms For Booking ID " + BookingID+" Successfully");


        }


        [HttpGet("GetBookingRoomByID/{BookingRoomID}", Name = "GetBookingRoomByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingRoomDTO> GetBookingRoomByID(int BookingRoomID)
        {
            if (BookingRoomID < 1)
                return BadRequest("Not Accepted ID : " + BookingRoomID);

            clsBookingRoom BookingRoom = clsBookingRoom.Find(BookingRoomID);

            if (BookingRoom == null)
                return NotFound("BookingRoom With ID : " + BookingRoomID + " Not Found !");

            return Ok(BookingRoom.bookingRoomDTO);

        }


        [HttpPost("AddBookingRoom", Name = "AddBookingRoom")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BookingRoomDTO> AddBookingRoom(BookingRoomDTO NewBookingRoomDTO)
        {
            if (NewBookingRoomDTO == null || NewBookingRoomDTO.BookingID<1||NewBookingRoomDTO.RoomID<1)
                return BadRequest("Invalid BookingRoom Data !");

            if (!clsBooking.IsBookingExist(NewBookingRoomDTO.BookingID))
                return BadRequest("Booking with id : " + NewBookingRoomDTO.BookingID + " Not Found");

            if (!clsRoom.IsRoomExist(NewBookingRoomDTO.RoomID))
                return BadRequest("Room with id : " + NewBookingRoomDTO.RoomID + " Not Found");


            clsBookingRoom BookingRoom = new clsBookingRoom(new BookingRoomDTO(-1,NewBookingRoomDTO.BookingID,
                NewBookingRoomDTO.RoomID));

            if (!BookingRoom.Save())
                return StatusCode(500, "Error Add BookingRoom");

            NewBookingRoomDTO.BookingRoomID = BookingRoom.BookingRoomID;


            return CreatedAtRoute("GetBookingRoomByID", new { BookingRoomID = NewBookingRoomDTO.BookingRoomID }, NewBookingRoomDTO);


        }


        [HttpPut("UpdateBookingRoom/{BookingRoomID}", Name = "UpdateBookingRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingRoomDTO> UpdateBookingRoom(int BookingRoomID, BookingRoomDTO UpdatedBookingRoomDTO)
        {
            if (UpdatedBookingRoomDTO == null || UpdatedBookingRoomDTO.BookingID < 1 || UpdatedBookingRoomDTO.RoomID < 1)
                return BadRequest("Invalid BookingRoom Data !");

            clsBookingRoom BookingRoom = clsBookingRoom.Find(BookingRoomID);

            if (BookingRoom == null)
                return NotFound("BookingRoom With ID : " + BookingRoomID + " Not Found !");

            if (BookingRoom.BookingID!=UpdatedBookingRoomDTO.BookingID&&  !clsBooking.IsBookingExist(UpdatedBookingRoomDTO.BookingID))
                return BadRequest("Booking with id : " + UpdatedBookingRoomDTO.BookingID + " Not Found");

            if (BookingRoom.RoomID!=UpdatedBookingRoomDTO.RoomID&& !clsRoom.IsRoomExist(UpdatedBookingRoomDTO.RoomID))
                return BadRequest("Room with id : " + UpdatedBookingRoomDTO.RoomID + " Not Found");


            if (!BookingRoom.Save())
                return StatusCode(500, "Error Updating BookingRoom");



            return Ok(BookingRoom.bookingRoomDTO);

        }


    }
}
