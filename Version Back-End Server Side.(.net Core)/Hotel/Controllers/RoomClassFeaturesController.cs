using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/RoomClassFeatures")]
    [ApiController]
    public class RoomClassFeaturesController : ControllerBase
    {
        [HttpGet("GetAllRoomClassFeatures", Name = "GetAllRoomClassFeatures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RoomClassFeaturesListDTO>> GetAllRoomClassFeatures()
        {
            List<RoomClassFeaturesListDTO> RoomClassFeaturesList = clsRoomClassFeature.GetAllRoomClassFeatures();

            if (RoomClassFeaturesList.Count == 0)
                return NotFound("Not  RoomClass Features Found !");

            return Ok(RoomClassFeaturesList);
        }

        [HttpGet("GetAllFeaturesForRoomClass/{RoomClassID}", Name = "GetAllFeaturesForRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FeaturesForRoomClassListDTO>> GetAllFeaturesForRoomClass(int RoomClassID)
        {
            if (RoomClassID < 1)
                return BadRequest("Not Accept ID :" + RoomClassID);

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("Room Class With ID " + RoomClassID + " Not Found");



            List<FeaturesForRoomClassListDTO> featuresForRoomClassLists = clsRoomClassFeature.GetAllFeaturesForRoomClass(RoomClassID);

            if (featuresForRoomClassLists.Count == 0)
                return NotFound("Not features For RoomClass With ID " + RoomClassID);

            return Ok(featuresForRoomClassLists);
        }


        [HttpGet("IsRoomClassFeatureExistByFeatureAndRoomClass/{RoomClassID},{FeatureID}", Name = "IsRoomClassFeatureExistByFeatureAndRoomClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsRoomClassFeatureExistByFeatureAndRoomClass(int RoomClassID, int FeatureID)
        {
            if (RoomClassID < 1 || FeatureID < 1)
                return BadRequest("Invalide Data !");

            if (!clsRoomClass.IsRoomClassExist(RoomClassID))
                return NotFound("Room Class With ID " + RoomClassID + " Not Found");

            if (!clsFeature.IsFeatureExist(FeatureID))
                return NotFound("Feature With ID " + FeatureID + " Not Found");

            return Ok(clsRoomClassFeature.IsRoomClassFeatureExistByFeatureAndRoomClass(RoomClassID, FeatureID));
        }



        [HttpDelete("DeleteRoomClassFeature/{RoomClassFeatureID}", Name = "DeleteRoomClassFeature")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteRoomClassFeature(int RoomClassFeatureID)
        {
            if (RoomClassFeatureID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassFeatureID);

            if (clsRoomClassFeature.Find(RoomClassFeatureID) == null)
                return NotFound("RoomClassFeature with id : " + RoomClassFeatureID + " Not Found !");

            if (!clsRoomClassFeature.DeleteRoomClassFeature(RoomClassFeatureID))
                return StatusCode(500, "Error delete RoomClassFeature");


            return Ok("RoomClassFeature with id : " + RoomClassFeatureID + " has been deleted");


        }



        [HttpGet("GetRoomClassFeatureByID/{RoomClassFeatureID}", Name = "GetRoomClassFeatureByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomClassFeatureDTO> GetRoomClassFeatureByID(int RoomClassFeatureID)
        {
            if (RoomClassFeatureID < 1)
                return BadRequest("Not Accepted ID : " + RoomClassFeatureID);

            clsRoomClassFeature RoomClassFeature = clsRoomClassFeature.Find(RoomClassFeatureID);

            if (RoomClassFeature == null)
                return NotFound("RoomClassFeature With ID : " + RoomClassFeatureID + " Not Found !");

            return Ok(RoomClassFeature.roomClassFeatureDTO);

        }


        [HttpPost("AddRoomClassFeature", Name = "AddRoomClassFeature")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RoomClassFeatureDTO> AddRoomClassFeature(RoomClassFeatureDTO NewRoomClassFeatureDTO)
        {
            if (NewRoomClassFeatureDTO == null || NewRoomClassFeatureDTO.RoomClassID < 1 ||
                NewRoomClassFeatureDTO.FeatureID < 1)
                return BadRequest("Invalid RoomClassFeature Data !");



            if (!clsRoomClass.IsRoomClassExist(NewRoomClassFeatureDTO.RoomClassID))
                return NotFound("Room Class With ID " + NewRoomClassFeatureDTO.RoomClassID + " Not Found");


            if (!clsFeature.IsFeatureExist(NewRoomClassFeatureDTO.FeatureID))
                return NotFound("Feature With ID " + NewRoomClassFeatureDTO.FeatureID + " Not Found");



            clsRoomClassFeature RoomClassFeature = new clsRoomClassFeature(new RoomClassFeatureDTO(-1, NewRoomClassFeatureDTO.RoomClassID,
                NewRoomClassFeatureDTO.FeatureID));

            if (!RoomClassFeature.Save())
                return StatusCode(500, "Error Add RoomClassFeature");

            NewRoomClassFeatureDTO.RoomClassFeatureID = RoomClassFeature.RoomClassFeatureID;


            return CreatedAtRoute("GetRoomClassFeatureByID", new { RoomClassFeatureID = NewRoomClassFeatureDTO.RoomClassFeatureID }, NewRoomClassFeatureDTO);


        }


        [HttpPut("UpdateRoomClassFeature/{RoomClassFeatureID}", Name = "UpdateRoomClassFeature")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomClassFeatureDTO> UpdateRoomClassFeature(int RoomClassFeatureID, RoomClassFeatureDTO UpdatedRoomClassFeatureDTO)
        {
            if (UpdatedRoomClassFeatureDTO == null || RoomClassFeatureID < 1 || UpdatedRoomClassFeatureDTO.RoomClassID < 1 ||
                UpdatedRoomClassFeatureDTO.FeatureID < 1 )
                return BadRequest("Invalid RoomClassFeature Data !");

            clsRoomClassFeature RoomClassFeature = clsRoomClassFeature.Find(RoomClassFeatureID);

            if (RoomClassFeature == null)
                return NotFound("RoomClassFeature With ID : " + RoomClassFeatureID + " Not Found !");

            if (RoomClassFeature.RoomClassID != UpdatedRoomClassFeatureDTO.RoomClassID && !clsRoomClass.IsRoomClassExist(UpdatedRoomClassFeatureDTO.RoomClassID))
                return NotFound("RoomClassID : " + UpdatedRoomClassFeatureDTO.RoomClassID + " Not Found");

            if (RoomClassFeature.FeatureID != UpdatedRoomClassFeatureDTO.FeatureID && !clsFeature.IsFeatureExist(UpdatedRoomClassFeatureDTO.FeatureID))
                return NotFound("Feature : " + UpdatedRoomClassFeatureDTO.FeatureID + " Not Found");


            RoomClassFeature.RoomClassID = UpdatedRoomClassFeatureDTO.RoomClassID;
            RoomClassFeature.FeatureID = UpdatedRoomClassFeatureDTO.FeatureID;
            


            if (!RoomClassFeature.Save())
                return StatusCode(500, "Error Updating RoomClassFeature");



            return Ok(RoomClassFeature.roomClassFeatureDTO);

        }

    }
}
