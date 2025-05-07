using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/RoomClasses")]
    [ApiController]
    public class RoomClassesController : ControllerBase
    {
        [HttpGet("GetAllRoomClasses", Name = "GetAllRoomClasses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RoomClassDTO>> GetAllRoomClasses()
        {
            List<RoomClassesListDTO> RoomClassesList = clsRoomClass.GetAllRoomClasses();

            if (RoomClassesList.Count == 0)
                return NotFound("Not  Room Classes Found !");

            return Ok(RoomClassesList);
        }

        [HttpGet("IsRoomClassExistByName/{RoomClassName}", Name = "IsRoomClassExistByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsRoomClassExistByName(string RoomClassName)
        {
            if (string.IsNullOrEmpty(RoomClassName))
                return BadRequest("Not Accepted RoomClassName : " + RoomClassName);


            return Ok(clsRoomClass.IsRoomClassExist(RoomClassName));
        }


        [HttpGet("IsRoomClassExistByID/{RoomClassID}", Name = "IsRoomClassExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsRoomClassExistByID(int RoomClassID)
        {
            if (RoomClassID<1)
                return BadRequest("Not Accepted ID : " + RoomClassID);

            return Ok(clsRoomClass.IsRoomClassExist(RoomClassID));
        }


        [HttpDelete("DeleteRoomClass/{RoomClassID}", Name = "DeleteRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteRoomClass(int RoomClassID)
        {
            if (RoomClassID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassID);

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("RoomClass with id : " + RoomClassID + " Not Found !");

            if (!clsRoomClass.DeleteRoomClass(RoomClassID))
                return StatusCode(500, "Error delete RoomClass");


            return Ok("RoomClass with id : " + RoomClassID + " has been deleted");


        }


        [HttpGet("GetRoomClassByID/{RoomClassID}", Name = "GetRoomClassByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomClassDTO> GetRoomClassByID(int RoomClassID)
        {
            if (RoomClassID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassID);

            clsRoomClass RoomClass = clsRoomClass.Find(RoomClassID);

            if (RoomClass == null)
                return NotFound("RoomClass With ID : " + RoomClassID + " Not Found !");

            return Ok(RoomClass.roomClassDTO);

        }


        [HttpGet("GetRoomClassByName/{RoomClassName}", Name = "GetRoomClassByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomClassDTO> GetRoomClassByName(string RoomClassName)
        {
            if (string.IsNullOrEmpty(RoomClassName))
                return BadRequest("Not Accepted RoomClass Name : " + RoomClassName);

            clsRoomClass RoomClass = clsRoomClass.Find(RoomClassName);

            if (RoomClass == null)
                return NotFound("RoomClass With Name : " + RoomClassName + " Not Found !");

            return Ok(RoomClass.roomClassDTO);

        }


        [HttpPost("AddRoomClass", Name = "AddRoomClass")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoomClassDTO> AddRoomClass(RoomClassDTO NewRoomClassDTO)
        {
            if (NewRoomClassDTO == null || string.IsNullOrEmpty(NewRoomClassDTO.RoomClassName)||
                !clsValidation.IsNumber(Convert.ToString(NewRoomClassDTO.BasePrice)))
                return BadRequest("Invalid RoomClass Data !");

            if (clsRoomClass.IsRoomClassExist(NewRoomClassDTO.RoomClassName))
                return BadRequest("RoomClassName : " + NewRoomClassDTO.RoomClassName + " Already exist");


            clsRoomClass RoomClass = new clsRoomClass(new RoomClassDTO(-1, NewRoomClassDTO.RoomClassName,
                NewRoomClassDTO.BasePrice));

            if (!RoomClass.Save())
                return StatusCode(500, "Error Add RoomClass");

            NewRoomClassDTO.RoomClassID = RoomClass.RoomClassID;


            return CreatedAtRoute("GetRoomClassByID", new { RoomClassID = NewRoomClassDTO.RoomClassID }, NewRoomClassDTO);


        }


        [HttpPut("UpdateRoomClass/{RoomClassID}", Name = "UpdateRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomClassDTO> UpdateRoomClass(int RoomClassID, RoomClassDTO UpdatedRoomClassDTO)
        {
            if (UpdatedRoomClassDTO == null || string.IsNullOrEmpty(UpdatedRoomClassDTO.RoomClassName) ||
                RoomClassID < 1|| !clsValidation.IsNumber(Convert.ToString(UpdatedRoomClassDTO.BasePrice)))
                return BadRequest("Invalid RoomClass Data !");

            clsRoomClass RoomClass = clsRoomClass.Find(RoomClassID);

            if (RoomClass == null)
                return NotFound("RoomClass With ID : " + RoomClassID + " Not Found !");

            if (RoomClass.RoomClassName != UpdatedRoomClassDTO.RoomClassName && clsRoomClass.IsRoomClassExist(UpdatedRoomClassDTO.RoomClassName))
                return BadRequest("RoomClassName : " + UpdatedRoomClassDTO.RoomClassName + " Already exist");

            RoomClass.RoomClassName = UpdatedRoomClassDTO.RoomClassName;
            RoomClass.BasePrice = UpdatedRoomClassDTO.BasePrice;


            if (!RoomClass.Save())
                return StatusCode(500, "Error Updating RoomClass");



            return Ok(RoomClass.roomClassDTO);

        }

    }
}
