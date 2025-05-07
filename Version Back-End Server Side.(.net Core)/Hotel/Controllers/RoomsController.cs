using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        [HttpGet("GetAllRooms", Name = "GetAllRooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RoomsListDTO>> GetAllRooms()
        {
            List<RoomsListDTO> RoomsList = clsRoom.GetAllRooms();

            if (RoomsList.Count == 0)
                return NotFound("Not  Rooms Found !");

            return Ok(RoomsList);
        }


        [HttpGet("GetAllRoomsForPageNumber/{PageNumber}", Name = "GetAllRoomsForPageNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<RoomsListDTO>> GetAllRoomsForPageNumber(int PageNumber)
        {
            if (!clsValidation.ValidateInteger(Convert.ToString(PageNumber)))
                return BadRequest("Invalide Page Number " + PageNumber);

            List<RoomsListDTO> RoomsList = clsRoom.GetAllRoomsForPageNumber(PageNumber);

            if (RoomsList.Count == 0)
                return NotFound("Not  Rooms Found !");

            return Ok(RoomsList);
        }

        [HttpGet("GetRoom/{RoomID}", Name = "GetRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RoomsListDTO>> GetRoom(int RoomID)
        {
            if(!clsRoom.IsRoomExist(RoomID))
                return NotFound("Room With ID "+RoomID+" Not Found !");


            List<RoomsListDTO> Room = clsRoom.GetRoom(RoomID);

            
            return Ok(Room);
        }




        [HttpGet("GetAllRoomsForRoomClass/{RoomClassID}", Name = "GetAllRoomsForRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<RoomsListDTO>> GetAllRoomsForRoomClass(int RoomClassID)
        {
            if (RoomClassID < 1)
                return BadRequest("Not Accept ID " + RoomClassID);

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("RoomClass With ID " + RoomClassID + " Not Found");


            List<RoomsListDTO> RoomsForRoomClass = clsRoom.GetAllRoomsForRoomClass(RoomClassID);

            if (RoomsForRoomClass.Count == 0)
                return NotFound("Not  Rooms For RoomClassID "+RoomClassID+"  Found !");

            return Ok(RoomsForRoomClass);
        }

        [HttpGet("IsRoomExistByID/{RoomID}", Name = "IsRoomExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsRoomExistByID(int RoomID)
        {
            if (RoomID < 1)
                return BadRequest("Not Accepted ID : " + RoomID);



            return Ok(clsRoom.IsRoomExist(RoomID));
        }

        [HttpGet("IsRoomNumberExist/{RoomNumber}", Name = "IsRoomNumberExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsRoomNumberExist(int RoomNumber)
        {
            if (!clsValidation.IsNumber(Convert.ToString(RoomNumber)))
                return BadRequest("Not Accepted Number : " + RoomNumber);



            return Ok(clsRoom.IsRoomNumberExist(RoomNumber));
        }



        [HttpPut("UpdateRoomStatus/{RoomID},{NewStatus}", Name = "UpdateRoomStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomDTO> UpdateRoomStatus(int RoomID,bool NewStatus)
        {
            if (RoomID<1)
                return BadRequest("Invalid Room Data !");

            clsRoom Room = clsRoom.FindByID(RoomID);

            if (Room == null)
                return NotFound("Room With ID : " + RoomID + " Not Found !");



           
            

            if (!Room.UpdateStatus(NewStatus))
                return StatusCode(500, "Error Updating Room Status");



            return Ok(Room.roomDTO);

        }


        [HttpDelete("DeleteRoom/{RoomID}", Name = "DeleteRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteRoom(int RoomID)
        {
            if (RoomID < 1)
                return BadRequest("Not Accepted ID : " + RoomID);

            if (clsRoom.IsRoomExist(RoomID))
                return NotFound("Room with id : " + RoomID + " Not Found !.no row deleted");

            if (!clsRoom.DeleteRoom(RoomID))
                return StatusCode(500, "Error delete Room");


            return Ok("Room with id : " + RoomID + " has been deleted");


        }


        [HttpGet("GetRoomByID/{RoomID}", Name = "GetRoomByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomDTO> GetRoomByID(int RoomID)
        {
            if (RoomID < 1)
                return BadRequest("Not Accepted ID : " + RoomID);

            clsRoom Room = clsRoom.FindByID(RoomID);

            if (Room == null)
                return NotFound("Room With ID : " + RoomID + " Not Found !");

            return Ok(Room.roomDTO);

        }


        [HttpGet("GetRoomByRoomNumber/{RoomNumber}", Name = "GetRoomByRoomNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomDTO> GetRoomByRoomNumber(int RoomNumber)
        {
            if (!clsValidation.IsNumber(Convert.ToString(RoomNumber)))
                return BadRequest("Not Accepted Number : " + RoomNumber);

            clsRoom Room = clsRoom.FindByRoomNumber(RoomNumber);

            if (Room == null)
                return NotFound("Room With Number : " + RoomNumber + " Not Found !");

            return Ok(Room.roomDTO);

        }





        [HttpPost("AddRoom", Name = "AddRoom")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoomDTO> AddRoom(RoomDTO NewRoomDTO)
        {
            if (NewRoomDTO == null || NewRoomDTO.FloorID<1||NewRoomDTO.RoomClassID<1||
                !clsValidation.IsNumber(Convert.ToString(NewRoomDTO.RoomNumber)))
                return BadRequest("Invalid Room Data !");

            if (!clsRoomClass.IsRoomClassExist(NewRoomDTO.RoomClassID))
                return NotFound("Room Class With ID " + NewRoomDTO.RoomClassID + " Not Found");

            if (clsFloor.FindByID(NewRoomDTO.FloorID)==null)
                return NotFound("Floor With ID " + NewRoomDTO.FloorID + " Not Found");



            if (clsRoom.IsRoomNumberExist(NewRoomDTO.RoomNumber))
                return BadRequest("RoomNumber : " + NewRoomDTO.RoomNumber + " Already exist");


            clsRoom Room = new clsRoom(new RoomDTO(-1,NewRoomDTO.FloorID,NewRoomDTO.RoomClassID,
                NewRoomDTO.RoomNumber,NewRoomDTO.Available));

            if (!Room.Save())
                return StatusCode(500, "Error Add Room");

            NewRoomDTO.RoomID = Room.RoomID;


            return CreatedAtRoute("GetRoomByID", new { RoomID = NewRoomDTO.RoomID }, NewRoomDTO);


        }


        [HttpPut("UpdateRoom/{RoomID}", Name = "UpdateRoom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomDTO> UpdateRoom(int RoomID, RoomDTO UpdatedRoomDTO)
        {
            if (UpdatedRoomDTO == null||RoomID<1 || UpdatedRoomDTO.FloorID < 1 || UpdatedRoomDTO.RoomClassID < 1 ||
                !clsValidation.IsNumber(Convert.ToString(UpdatedRoomDTO.RoomNumber)))
                return BadRequest("Invalid Room Data !");


            clsRoom Room = clsRoom.FindByID(RoomID);

            if (Room == null)
                return NotFound("Room With ID : " + RoomID + " Not Found !");

            if (Room.RoomClassID!=UpdatedRoomDTO.RoomClassID&&  !clsRoomClass.IsRoomClassExist(UpdatedRoomDTO.RoomClassID))
                return NotFound("Room Class With ID " + UpdatedRoomDTO.RoomClassID + " Not Found");

            if (Room.FloorID!=UpdatedRoomDTO.FloorID&&  clsFloor.FindByID(UpdatedRoomDTO.FloorID) == null)
                return NotFound("Floor With ID " + UpdatedRoomDTO.FloorID + " Not Found");



            if (Room.RoomNumber!=UpdatedRoomDTO.RoomNumber&&  clsRoom.IsRoomNumberExist(UpdatedRoomDTO.RoomNumber))
                return BadRequest("RoomNumber : " + UpdatedRoomDTO.RoomNumber + " Already exist");

            

            

            Room.RoomNumber = UpdatedRoomDTO.RoomNumber;
            Room.RoomClassID = UpdatedRoomDTO.RoomClassID;
            Room.FloorID = UpdatedRoomDTO.FloorID;
            Room.Available = UpdatedRoomDTO.Available;


            if (!Room.Save())
                return StatusCode(500, "Error Updating Room");



            return Ok(Room.roomDTO);

        }

    }
}
