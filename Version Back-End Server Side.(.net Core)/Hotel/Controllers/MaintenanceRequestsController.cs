using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/MaintenanceRequests")]
    [ApiController]
    public class MaintenanceRequestsController : ControllerBase
    {
        [HttpGet("GetAllMaintenanceRequests", Name = "GetAllMaintenanceRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MaintenanceRequestsListDTO>> GetAllMaintenanceRequests()
        {
            List<MaintenanceRequestsListDTO> MaintenanceRequestsList = clsMaintenanceRequest.GetAllMaintenanceRequests();

            if (MaintenanceRequestsList.Count == 0)
                return NotFound("Not  Maintenance Requests Found !");

            return Ok(MaintenanceRequestsList);
        }


        [HttpDelete("DeleteMaintenanceRequest/{MaintenanceRequestID}", Name = "DeleteMaintenanceRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteMaintenanceRequest(int MaintenanceRequestID)
        {
            if (MaintenanceRequestID < 1)
                return BadRequest("Not Accepted ID : " + MaintenanceRequestID);

            if (clsMaintenanceRequest.Find(MaintenanceRequestID)==null)
                return NotFound("MaintenanceRequest with id : " + MaintenanceRequestID + " Not Found !");

            if (!clsMaintenanceRequest.DeleteMaintenanceRequest(MaintenanceRequestID))
                return StatusCode(500, "Error delete MaintenanceRequest");


            return Ok("MaintenanceRequest with id : " + MaintenanceRequestID + " has been deleted");


        }



        [HttpPut("SetCompleteMaintenance/{MaintenanceRequestID}", Name = "SetCompleteMaintenance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MaintenanceRequestDTO> SetCompleteMaintenance(int MaintenanceRequestID)
        {
            if (MaintenanceRequestID<1)
                return BadRequest("Not Accept ID "+ MaintenanceRequestID);

            clsMaintenanceRequest maintenanceRequest = clsMaintenanceRequest.Find(MaintenanceRequestID);

            if (maintenanceRequest == null)
                return NotFound("maintenanceRequest With ID : " + MaintenanceRequestID + " Not Found !");

            if (maintenanceRequest.IsCompleted)
                return BadRequest("Maintenance with id : " + MaintenanceRequestID + " Already Completed");

            


            if (!maintenanceRequest.SetCompleteMaintenance())
                return StatusCode(500, "Error Completed Maintenance");



            return Ok(maintenanceRequest.maintenanceRequestDTO);

        }


        [HttpGet("GetMaintenanceRequestByID/{MaintenanceRequestID}", Name = "GetMaintenanceRequestByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MaintenanceRequestDTO> GetMaintenanceRequestByID(int MaintenanceRequestID)
        {
            if (MaintenanceRequestID < 1)
                return BadRequest("Not Accepted ID : " + MaintenanceRequestID);

            clsMaintenanceRequest MaintenanceRequest = clsMaintenanceRequest.Find(MaintenanceRequestID);

            if (MaintenanceRequest == null)
                return NotFound("MaintenanceRequest With ID : " + MaintenanceRequestID + " Not Found !");

            return Ok(MaintenanceRequest.maintenanceRequestDTO);

        }


        [HttpPost("AddMaintenanceRequest", Name = "AddMaintenanceRequest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MaintenanceRequestDTO> AddMaintenanceRequest(MaintenanceRequestDTO NewMaintenanceRequestDTO)
        {
            if (NewMaintenanceRequestDTO == null || NewMaintenanceRequestDTO.RoomID<1||
                NewMaintenanceRequestDTO.CreatedByEmployeeID<1)
                return BadRequest("Invalid MaintenanceRequest Data !");

            if (!clsRoom.IsRoomExist(NewMaintenanceRequestDTO.RoomID))
                return NotFound("Room With ID : " + NewMaintenanceRequestDTO.RoomID + " Not Found !");

            if (!clsEmployee.IsEmployeeExist(NewMaintenanceRequestDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + NewMaintenanceRequestDTO.CreatedByEmployeeID + " NotFound");


            clsMaintenanceRequest MaintenanceRequest = new clsMaintenanceRequest(new MaintenanceRequestDTO(-1,NewMaintenanceRequestDTO.RoomID,
                NewMaintenanceRequestDTO.MaintenanceRequestDate,false,null, NewMaintenanceRequestDTO.Description, NewMaintenanceRequestDTO.CreatedByEmployeeID));

            if (!MaintenanceRequest.Save())
                return StatusCode(500, "Error Add MaintenanceRequest");

            NewMaintenanceRequestDTO.MaintenanceRequestID = MaintenanceRequest.MaintenanceRequestID;


            return CreatedAtRoute("GetMaintenanceRequestByID", new { MaintenanceRequestID = NewMaintenanceRequestDTO.MaintenanceRequestID }, NewMaintenanceRequestDTO);


        }


        [HttpPut("UpdateMaintenanceRequest/{MaintenanceRequestID}", Name = "UpdateMaintenanceRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MaintenanceRequestDTO> UpdateMaintenanceRequest(int MaintenanceRequestID, MaintenanceRequestDTO UpdatedMaintenanceRequestDTO)
        {
            if (UpdatedMaintenanceRequestDTO == null||MaintenanceRequestID<1 || UpdatedMaintenanceRequestDTO.RoomID < 1 ||
                UpdatedMaintenanceRequestDTO.CreatedByEmployeeID < 1)
                return BadRequest("Invalid MaintenanceRequest Data !");

            clsMaintenanceRequest MaintenanceRequest = clsMaintenanceRequest.Find(MaintenanceRequestID);

            if (MaintenanceRequest == null)
                return NotFound("MaintenanceRequest With ID : " + MaintenanceRequestID + " Not Found !");

            if (MaintenanceRequest.RoomID!=UpdatedMaintenanceRequestDTO.RoomID&& !clsRoom.IsRoomExist(UpdatedMaintenanceRequestDTO.RoomID))
                return NotFound("Room With ID : " + UpdatedMaintenanceRequestDTO.RoomID + " Not Found !");



            if (MaintenanceRequest.CreatedByEmployeeID != UpdatedMaintenanceRequestDTO.CreatedByEmployeeID && !clsEmployee.IsEmployeeExist(UpdatedMaintenanceRequestDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + UpdatedMaintenanceRequestDTO.CreatedByEmployeeID + " NotFound");

            MaintenanceRequest.RoomID = UpdatedMaintenanceRequestDTO.RoomID;
            MaintenanceRequest.MaintenanceRequestDate = UpdatedMaintenanceRequestDTO.MaintenanceRequestDate;
            MaintenanceRequest.IsCompleted = UpdatedMaintenanceRequestDTO.IsCompleted;
            MaintenanceRequest.CompletedDate = UpdatedMaintenanceRequestDTO.CompletedDate;
            MaintenanceRequest.CreatedByEmployeeID = UpdatedMaintenanceRequestDTO.CreatedByEmployeeID;
            MaintenanceRequest.Description = UpdatedMaintenanceRequestDTO.Description;


            if (!MaintenanceRequest.Save())
                return StatusCode(500, "Error Updating MaintenanceRequest");



            return Ok(MaintenanceRequest.maintenanceRequestDTO);

        }
    }
}
