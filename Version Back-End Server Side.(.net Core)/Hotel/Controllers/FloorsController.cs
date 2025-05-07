using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Floors")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        [HttpGet("GetAllFloors", Name = "GetAllFloors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FloorsListDTO>> GetAllFloors()
        {
            List<FloorsListDTO> FloorsList = clsFloor.GetAllFloors();

            if (FloorsList.Count == 0)
                return NotFound("Not  Floors Found !");

            return Ok(FloorsList);
        }

        [HttpGet("IsFloorNumberExist/{FloorNumber}", Name = "IsFloorNumberExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsFloorNumberExist(byte FloorNumber)
        {
           

            return Ok(clsFloor.IsFloorNumberExist(FloorNumber));
        }

        [HttpDelete("DeleteFloor/{FloorID}", Name = "DeleteFloor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteFloor(int FloorID)
        {
            if (FloorID < 1)
                return BadRequest("Not Accepted ID : " + FloorID);

            if (clsFloor.FindByID(FloorID) == null)
                return NotFound("Floor with id : " + FloorID + " Not Found !");

            if (!clsFloor.DeleteFloor(FloorID))
                return StatusCode(500, "Error delete Floor");


            return Ok("Floor with id : " + FloorID + " has been deleted");


        }

        [HttpGet("GetFloorByID/{FloorID}", Name = "GetFloorByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FloorDTO> GetFloorByID(int FloorID)
        {
            if (FloorID < 1)
                return BadRequest("Not Accepted ID : " + FloorID);

            clsFloor Floor = clsFloor.FindByID(FloorID);

            if (Floor == null)
                return NotFound("Floor With ID : " + FloorID + " Not Found !");

            return Ok(Floor.floorDTO);

        }

        [HttpGet("GetFloorByFloorNumber/{FloorNumber}", Name = "GetFloorByFloorNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FloorDTO> GetFloorByFloorNumber(byte FloorNumber)
        {
            if (!clsValidation.IsNumber(Convert.ToString(FloorNumber)))
                return BadRequest("No Accept FloorNumber : " + FloorNumber);
           
            clsFloor Floor = clsFloor.FindByFloorNumber(FloorNumber);

            if (Floor == null)
                return NotFound("Floor  With Number : " + FloorNumber + " Not Found !");

            return Ok(Floor.floorDTO);

        }


        [HttpPost("AddFloor", Name = "AddFloor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FloorDTO> AddFloor(FloorDTO NewFloorDTO)
        {
            if (NewFloorDTO == null || !clsValidation.IsNumber(Convert.ToString(NewFloorDTO.FloorNumber))||
                !clsValidation.IsNumber(Convert.ToString(NewFloorDTO.FloorArea)))
                return BadRequest("Invalid Floor Data !");

            

            if (clsFloor.IsFloorNumberExist(NewFloorDTO.FloorNumber))
                return BadRequest("FloorNumber : " + NewFloorDTO.FloorNumber + " Already exist");


            clsFloor Floor = new clsFloor(new FloorDTO(-1,NewFloorDTO.FloorNumber,
                NewFloorDTO.FloorArea));

            if (!Floor.Save())
                return StatusCode(500, "Error Add Floor");

            NewFloorDTO.FloorID = Floor.FloorID;


            return CreatedAtRoute("GetFloorByID", new { FloorID = NewFloorDTO.FloorID }, NewFloorDTO);


        }


        [HttpPut("UpdateFloor/{FloorID}", Name = "UpdateFloor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FloorDTO> UpdateFloor(int FloorID, FloorDTO UpdatedFloorDTO)
        {
            if (UpdatedFloorDTO == null || !clsValidation.IsNumber(Convert.ToString(UpdatedFloorDTO.FloorNumber)) ||
              !clsValidation.IsNumber(Convert.ToString(UpdatedFloorDTO.FloorArea)) || FloorID<1)
                return BadRequest("Invalid Floor Data !");

            clsFloor Floor = clsFloor.FindByID(FloorID);

            if (Floor == null)
                return NotFound("Floor With ID : " + FloorID + " Not Found !");

            if (Floor.FloorNumber != UpdatedFloorDTO.FloorNumber && clsFloor.IsFloorNumberExist(UpdatedFloorDTO.FloorNumber))
                return BadRequest("FloorNumber : " + UpdatedFloorDTO.FloorNumber + " Already exist");

            Floor.FloorNumber = UpdatedFloorDTO.FloorNumber;
            Floor.FloorArea = UpdatedFloorDTO.FloorArea;


            if (!Floor.Save())
                return StatusCode(500, "Error Updating Floor");



            return Ok(Floor.floorDTO);

        }


    }

}
