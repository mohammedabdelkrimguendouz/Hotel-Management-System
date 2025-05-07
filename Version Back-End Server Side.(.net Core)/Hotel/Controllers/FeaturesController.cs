using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Features")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        [HttpGet("GetAllFeatures", Name = "GetAllFeatures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FeatureDTO>> GetAllFeatures()
        {
            List<FeatureDTO> FeaturesList = clsFeature.GetAllFeatures();

            if (FeaturesList.Count == 0)
                return NotFound("Not  Features Found !");

            return Ok(FeaturesList);
        }


        [HttpGet("IsFeatureExistByName/{FeatureName}", Name = "IsFeatureExistByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsFeatureExistByName(string FeatureName)
        {
            if (string.IsNullOrEmpty(FeatureName))
                return BadRequest("Not Accepted FeatureName : " + FeatureName);

            

            return Ok(clsFeature.IsFeatureExist(FeatureName));
        }


        [HttpGet("IsFeatureExistByID/{FeatureID}", Name = "IsFeatureExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsFeatureExistByID(int FeatureID)
        {
            if (FeatureID<1)
                return BadRequest("Not Accepted ID : " + FeatureID);



            return Ok(clsFeature.IsFeatureExist(FeatureID));
        }


        [HttpDelete("DeleteFeature/{FeatureID}", Name = "DeleteFeature")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteFeature(int FeatureID)
        {
            if (FeatureID < 1)
                return BadRequest("Not Accepted ID : " + FeatureID);

            if (!clsFeature.IsFeatureExist(FeatureID))
                return NotFound("Feature with id : " + FeatureID + " Not Found !");

            if (!clsFeature.DeleteFeature(FeatureID))
                return StatusCode(500, "Error delete Feature");


            return Ok("Feature with id : " + FeatureID + " has been deleted");


        }


        [HttpGet("GetFeatureByID/{FeatureID}", Name = "GetFeatureByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FeatureDTO> GetFeatureByID(int FeatureID)
        {
            if (FeatureID < 1)
                return BadRequest("Not Accepted ID : " + FeatureID);

            clsFeature Feature = clsFeature.Find(FeatureID);

            if (Feature == null)
                return NotFound("Feature With ID : " + FeatureID + " Not Found !");

            return Ok(Feature.featureDTO);

        }

        [HttpGet("GetFeatureByName/{FeatureName}", Name = "GetFeatureByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FeatureDTO> GetFeatureByName(string FeatureName)
        {
            if (string.IsNullOrEmpty(FeatureName))
                return BadRequest("Not Accepted Feature : " + FeatureName);

            clsFeature Feature = clsFeature.Find(FeatureName);

            if (Feature == null)
                return NotFound("Feature With Name : " + FeatureName + " Not Found !");

            return Ok(Feature.featureDTO);

        }


        [HttpPost("AddFeature", Name = "AddFeature")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FeatureDTO> AddFeature(FeatureDTO NewFeatureDTO)
        {
            if (NewFeatureDTO == null || string.IsNullOrEmpty(NewFeatureDTO.FeatureName))
                return BadRequest("Invalid Feature Data !");

            if (clsFeature.IsFeatureExist(NewFeatureDTO.FeatureName))
                return BadRequest("FeatureName : " + NewFeatureDTO.FeatureName + " Already exist");


            clsFeature Feature = new clsFeature(new FeatureDTO(-1, NewFeatureDTO.FeatureName,
                NewFeatureDTO.Description));

            if (!Feature.Save())
                return StatusCode(500, "Error Add Feature");

            NewFeatureDTO.FeatureID = Feature.FeatureID;


            return CreatedAtRoute("GetFeatureByID", new { FeatureID = NewFeatureDTO.FeatureID }, NewFeatureDTO);


        }


        [HttpPut("UpdateFeature/{FeatureID}", Name = "UpdateFeature")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FeatureDTO> UpdateFeature(int FeatureID, FeatureDTO UpdatedFeatureDTO)
        {
            if (UpdatedFeatureDTO == null || string.IsNullOrEmpty(UpdatedFeatureDTO.FeatureName) ||
                FeatureID < 1)
                return BadRequest("Invalid Feature Data !");

            clsFeature Feature = clsFeature.Find(FeatureID);

            if (Feature == null)
                return NotFound("Feature With ID : " + FeatureID + " Not Found !");

            if (Feature.FeatureName != UpdatedFeatureDTO.FeatureName && clsFeature.IsFeatureExist(UpdatedFeatureDTO.FeatureName))
                return BadRequest("FeatureName : " + UpdatedFeatureDTO.FeatureName + " Already exist");

            Feature.FeatureName = UpdatedFeatureDTO.FeatureName;
            Feature.Description = UpdatedFeatureDTO.Description;


            if (!Feature.Save())
                return StatusCode(500, "Error Updating Feature");



            return Ok(Feature.featureDTO);

        }

    }
}
