using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/RoomClassBedTypes")]
    [ApiController]
    public class RoomClassBedTypesController : ControllerBase
    {
        [HttpGet("GetAllRoomClassBedTypes", Name = "GetAllRoomClassBedTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RoomClassBedTypesListDTO>> GetAllRoomClassBedTypes()
        {
            List<RoomClassBedTypesListDTO> RoomClassBedTypesList = clsRoomClassBedType.GetAllRoomClassBedTypes();

            if (RoomClassBedTypesList.Count == 0)
                return NotFound("Not  Room Class Bed Types Found !");

            return Ok(RoomClassBedTypesList);
        }


        [HttpGet("GetAllBedTypesForRoomClass/{RoomClassID}", Name = "GetAllBedTypesForRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BedTypesForRoomClassListDTO>> GetAllBedTypesForRoomClass(int RoomClassID)
        {
            if(RoomClassID<1)
                return BadRequest("Not Accept ID :"+RoomClassID);

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("Room Class With ID " + RoomClassID + " Not Found");



            List<BedTypesForRoomClassListDTO> bedTypesForRoomClassLists = clsRoomClassBedType.GetAllBedTypesForRoomClass(RoomClassID);

            if (bedTypesForRoomClassLists.Count == 0)
                return NotFound("Not bedTypes For RoomClass With ID "+RoomClassID);

            return Ok(bedTypesForRoomClassLists);
        }



        [HttpGet("IsRoomClassBedTypeExistByBedTypeAndRoomClass/{RoomClassID},{BedTypeID}", Name = "IsRoomClassBedTypeExistByBedTypeAndRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsRoomClassBedTypeExistByBedTypeAndRoomClass(int RoomClassID, int BedTypeID)
        {
            if (RoomClassID < 1 || BedTypeID<1)
                return BadRequest("Invalide Data !");

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("Room Class With ID " + RoomClassID + " Not Found");

            if(clsBedType.Find(BedTypeID) == null)
                return NotFound("BedType With ID " + BedTypeID + " Not Found");

           

            return Ok(clsRoomClassBedType.IsRoomClassBedTypeExistByBedTypeAndRoomClass(RoomClassID, BedTypeID));
        }


        [HttpDelete("DeleteRoomClassBedType/{RoomClassBedTypeID}", Name = "DeleteRoomClassBedType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteRoomClassBedType(int RoomClassBedTypeID)
        {
            if (RoomClassBedTypeID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassBedTypeID);

            if (clsRoomClassBedType.Find(RoomClassBedTypeID)==null)
                return NotFound("RoomClassBedType with id : " + RoomClassBedTypeID + " Not Found !");

            if (!clsRoomClassBedType.DeleteRoomClassBedType(RoomClassBedTypeID))
                return StatusCode(500, "Error delete RoomClassBedType");


            return Ok("RoomClassBedType with id : " + RoomClassBedTypeID + " has been deleted");


        }

        [HttpGet("GetRoomClassBedTypeByID/{RoomClassBedTypeID}", Name = "GetRoomClassBedTypeByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomClassBedTypeDTO> GetRoomClassBedTypeByID(int RoomClassBedTypeID)
        {
            if (RoomClassBedTypeID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassBedTypeID);

            clsRoomClassBedType RoomClassBedType = clsRoomClassBedType.Find(RoomClassBedTypeID);

            if (RoomClassBedType == null)
                return NotFound("RoomClassBedType With ID : " + RoomClassBedTypeID + " Not Found !");

            return Ok(RoomClassBedType.roomClassBedTypeDTO);

        }



        [HttpPost("AddRoomClassBedType", Name = "AddRoomClassBedType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoomClassBedTypeDTO> AddRoomClassBedType(RoomClassBedTypeDTO NewRoomClassBedTypeDTO)
        {
            if (NewRoomClassBedTypeDTO == null || NewRoomClassBedTypeDTO.RoomClassID<1||
                NewRoomClassBedTypeDTO.BedTypeID<1||NewRoomClassBedTypeDTO.BedsNumber<0)
                return BadRequest("Invalid RoomClassBedType Data !");



            if (!clsRoomClass.IsRoomClassExist(NewRoomClassBedTypeDTO.RoomClassID))
                return NotFound("Room Class With ID " + NewRoomClassBedTypeDTO.RoomClassID + " Not Found");

            if (clsBedType.Find(NewRoomClassBedTypeDTO.BedTypeID) == null)
                return NotFound("BedType With ID " + NewRoomClassBedTypeDTO.BedTypeID + " Not Found");



            clsRoomClassBedType RoomClassBedType = new clsRoomClassBedType(new RoomClassBedTypeDTO(-1,NewRoomClassBedTypeDTO.RoomClassID,
                NewRoomClassBedTypeDTO.BedTypeID,NewRoomClassBedTypeDTO.BedsNumber));

            if (!RoomClassBedType.Save())
                return StatusCode(500, "Error Add RoomClassBedType");

            NewRoomClassBedTypeDTO.RoomClassBedTypeID = RoomClassBedType.RoomClassBedTypeID;


            return CreatedAtRoute("GetRoomClassBedTypeByID", new { RoomClassBedTypeID = NewRoomClassBedTypeDTO.RoomClassBedTypeID }, NewRoomClassBedTypeDTO);


        }


        [HttpPut("UpdateRoomClassBedType/{RoomClassBedTypeID}", Name = "UpdateRoomClassBedType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomClassBedTypeDTO> UpdateRoomClassBedType(int RoomClassBedTypeID, RoomClassBedTypeDTO UpdatedRoomClassBedTypeDTO)
        {
            if (UpdatedRoomClassBedTypeDTO == null||RoomClassBedTypeID<1 || UpdatedRoomClassBedTypeDTO.RoomClassID < 1 ||
                UpdatedRoomClassBedTypeDTO.BedTypeID < 1 || UpdatedRoomClassBedTypeDTO.BedsNumber < 0)
                return BadRequest("Invalid RoomClassBedType Data !");

            clsRoomClassBedType RoomClassBedType = clsRoomClassBedType.Find(RoomClassBedTypeID);

            if (RoomClassBedType == null)
                return NotFound("RoomClassBedType With ID : " + RoomClassBedTypeID + " Not Found !");

            if (RoomClassBedType.RoomClassID != UpdatedRoomClassBedTypeDTO.RoomClassID && !clsRoomClass.IsRoomClassExist(UpdatedRoomClassBedTypeDTO.RoomClassID))
                return NotFound("RoomClassID : " + UpdatedRoomClassBedTypeDTO.RoomClassID + " Not Found");

            if (RoomClassBedType.BedTypeID != UpdatedRoomClassBedTypeDTO.BedTypeID && clsBedType.Find(UpdatedRoomClassBedTypeDTO.BedTypeID)==null)
                return NotFound("BedTypeID : " + UpdatedRoomClassBedTypeDTO.BedTypeID + " Not Found");


            RoomClassBedType.RoomClassID = UpdatedRoomClassBedTypeDTO.RoomClassID;
            RoomClassBedType.BedTypeID = UpdatedRoomClassBedTypeDTO.BedTypeID;
            RoomClassBedType.BedsNumber = UpdatedRoomClassBedTypeDTO.BedsNumber;


            if (!RoomClassBedType.Save())
                return StatusCode(500, "Error Updating RoomClassBedType");



            return Ok(RoomClassBedType.roomClassBedTypeDTO);

        }



    }
}
