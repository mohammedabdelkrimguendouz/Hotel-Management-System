using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/BedTypes")]
    [ApiController]
    public class BedTypesController : ControllerBase
    {
        [HttpGet("GetAllBedTypes", Name = "GetAllBedTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BedTypeDTO>> GetAllBedTypes()
        {
            List<BedTypeDTO> BedTypesList = clsBedType.GetAllBedTypes();

            if (BedTypesList.Count == 0)
                return NotFound("Not  BedTypes Found !");

            return Ok(BedTypesList);
        }



        [HttpGet("IsBedTypeExistByName/{BedTypeName}", Name = "IsBedTypeExistByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsBedTypeExistByName(string BedTypeName)
        {
            if (string.IsNullOrEmpty(BedTypeName))
                return BadRequest("Not Accepted BedTypeName : " + BedTypeName);

            return Ok(clsBedType.IsBedTypeExist(BedTypeName));
        }


        [HttpDelete("DeleteBedType/{BedTypeID}", Name = "DeleteBedType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteBedType(int BedTypeID)
        {
            if (BedTypeID < 1)
                return BadRequest("Not Accepted ID : " + BedTypeID);

            if(clsBedType.Find(BedTypeID)==null)
                return NotFound("BedType with id : " + BedTypeID + " Not Found !");

            if (!clsBedType.DeleteBedType(BedTypeID))
                return StatusCode(500, "Error delete BedType");


            return Ok("BedType with id : " + BedTypeID + " has been deleted");


        }

        [HttpGet("GetBedTypeByID/{BedTypeID}", Name = "GetBedTypeByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BedTypeDTO> GetBedTypeByID(int BedTypeID)
        {
            if (BedTypeID < 1)
                return BadRequest("Not Accepted ID : " + BedTypeID);

            clsBedType BedType = clsBedType.Find(BedTypeID);

            if (BedType == null)
                return NotFound("BedType With ID : " + BedTypeID + " Not Found !");

            return Ok(BedType.bedTypeDTO);

        }

        [HttpGet("GetBedTypeByName/{BedTypeName}", Name = "GetBedTypeByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BedTypeDTO> GetBedTypeByName(string BedTypeName)
        {
            if (string.IsNullOrEmpty(BedTypeName))
                return BadRequest("Not Accepted BedType : " + BedTypeName);

            clsBedType BedType = clsBedType.Find(BedTypeName);

            if (BedType == null)
                return NotFound("BedType With ID : " + BedTypeName + " Not Found !");

            return Ok(BedType.bedTypeDTO);

        }

        [HttpPost("AddBedType",Name = "AddBedType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BedTypeDTO> AddBedType(BedTypeDTO NewBedTypeDTO)
        {
            if (NewBedTypeDTO == null || string.IsNullOrEmpty(NewBedTypeDTO.BedTypeName))
                return BadRequest("Invalid BedType Data !");

            if (clsBedType.IsBedTypeExist(NewBedTypeDTO.BedTypeName))
                return BadRequest("BedTypeName : " + NewBedTypeDTO.BedTypeName + " Already exist");


            clsBedType BedType = new clsBedType(new BedTypeDTO(-1,NewBedTypeDTO.BedTypeName,
                NewBedTypeDTO.Description));

            if (!BedType.Save())
                return StatusCode(500, "Error Add Bed Type");

            NewBedTypeDTO.BedTypeID = BedType.BedTypeID;


            return CreatedAtRoute("GetBedTypeByID", new { BedTypeID = NewBedTypeDTO.BedTypeID }, NewBedTypeDTO);


        }


        [HttpPut("UpdateBedType/{BedTypeID}", Name = "UpdateBedType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BedTypeDTO> UpdateBedType(int BedTypeID, BedTypeDTO UpdatedBedTypeDTO)
        {
            if (UpdatedBedTypeDTO == null || string.IsNullOrEmpty(UpdatedBedTypeDTO.BedTypeName)||
                BedTypeID<1)
                return BadRequest("Invalid BedType Data !");

            clsBedType BedType = clsBedType.Find(BedTypeID);

            if (BedType == null)
                return NotFound("BedType With ID : " + BedTypeID + " Not Found !");

            if(BedType.BedTypeName!=UpdatedBedTypeDTO.BedTypeName&&clsBedType.IsBedTypeExist(UpdatedBedTypeDTO.BedTypeName))
                return BadRequest("BedTypeName : " + UpdatedBedTypeDTO.BedTypeName + " Already exist");

            BedType.BedTypeName = UpdatedBedTypeDTO.BedTypeName;
            BedType.Description = UpdatedBedTypeDTO.Description;
            

            if (!BedType.Save())
                return StatusCode(500, "Error Updating BedType");



            return Ok(BedType.bedTypeDTO);

        }


    }
}
