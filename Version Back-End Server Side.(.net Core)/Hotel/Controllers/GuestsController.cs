using DVLD_Buisness;
using DVLD_Buisness.Global_Classes;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Controllers
{
    [Route("api/Guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        [HttpGet("GetAllGuests", Name = "GetAllGuests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<GuestsListDTO>> GetAllGuests()
        {
            List<GuestsListDTO> GuestsList = clsGuest.GetAllGuests();

            if (GuestsList.Count == 0)
                return NotFound("Not  Guests Found !");

            return Ok(GuestsList);
        }



        [HttpGet("GetAllGuestsForPageNumber/{PageNumber}", Name = "GetAllGuestsForPageNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<GuestsListDTO>> GetAllGuestsForPageNumber(int PageNumber)
        {
            if (!clsValidation.ValidateInteger(Convert.ToString(PageNumber)))
                return BadRequest("Invalide Page Number " + PageNumber);

            List<GuestsListDTO> GuestsList = clsGuest.GetAllGuestsForPageNumber(PageNumber);

            if (GuestsList.Count == 0)
                return NotFound("Not  Guests Found !");

            return Ok(GuestsList);
        }



        [HttpGet("IsGuestExistByID/{GuestID}", Name = "IsGuestExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsGuestExistByID(int GuestID)
        {
            if (GuestID < 1)
                return BadRequest("Not Accepted ID : " + GuestID);



            return Ok(clsGuest.IsGuestExistByGuestID(GuestID));
        }


        [HttpGet("IsGuestExistForNationalNo/{NationalNo}", Name = "IsGuestExistForNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsGuestExistForNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
                return BadRequest("Not Accepted Guest National No : " + NationalNo);



            return Ok(clsGuest.IsGuestExistForNationalNo(NationalNo));
        }



        [HttpDelete("DeleteGuest/{GuestID}", Name = "DeleteGuest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteGuest(int GuestID)
        {
            if (GuestID < 1)
                return BadRequest("Not Accepted ID : " + GuestID);

            clsGuest guest=clsGuest.FindByGuestID(GuestID);

            if (guest==null)
                return NotFound("Guest with id : " + GuestID + " Not Found !");

            if (!guest.DeleteGuest())
                return StatusCode(500, "Error delete Guest");


            return Ok("Guest with id : " + GuestID + " has been deleted");


        }


        [HttpGet("GetGuestByID/{GuestID}", Name = "GetGuestByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AllGuestInfoDTO> GetGuestByID(int GuestID)
        {
            if (GuestID < 1)
                return BadRequest("Not Accepted ID : " + GuestID);

            clsGuest Guest = clsGuest.FindByGuestID(GuestID);

            if (Guest == null)
                return NotFound("Guest With ID : " + GuestID + " Not Found !");

            return Ok(Guest.allGuestInfoDTO);

        }


        [HttpGet("GetGuestByNationalNo/{NationalNo}", Name = "GetGuestByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AllGuestInfoDTO> GetGuestByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
                return BadRequest("Not Accepted NationalNo : " + NationalNo);

            clsGuest Guest = clsGuest.FindByNationalNo(NationalNo);

            if (Guest == null)
                return NotFound("Guest With NationalNo : " + NationalNo + " Not Found !");

            return Ok(Guest.allGuestInfoDTO);

        }


        [HttpPost("AddGuest", Name = "AddGuest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AllGuestInfoDTO> AddGuest(AllGuestInfoDTO allGuestInfoDTO,
            clsPerson.enGender Gender)
        {
            if (allGuestInfoDTO == null ||allGuestInfoDTO.CreatedByEmployeeID<1|| string.IsNullOrEmpty(allGuestInfoDTO.NationalNo)||
                string.IsNullOrEmpty(allGuestInfoDTO.FirstName) || string.IsNullOrEmpty(allGuestInfoDTO.LastName) ||
                string.IsNullOrEmpty(allGuestInfoDTO.Phone)||!clsValidation.ValidateInteger(Convert.ToString(allGuestInfoDTO.Phone))
                || allGuestInfoDTO.NationalityCountryID<1
                )
                return BadRequest("Invalid Guest Data !");


            if (!string.IsNullOrEmpty(allGuestInfoDTO.Email) && !clsValidation.ValidateEmail(allGuestInfoDTO.Email))
                return BadRequest("Email " + allGuestInfoDTO.Email + " Not Valide");



            if (clsGuest.IsGuestExistForNationalNo(allGuestInfoDTO.NationalNo))
                return BadRequest("National No : " + allGuestInfoDTO.NationalNo + " Already exist");

            if (!clsEmployee.IsEmployeeExist(allGuestInfoDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + allGuestInfoDTO.CreatedByEmployeeID + " NotFound");


            if (clsCountry.Find(allGuestInfoDTO.NationalityCountryID) == null)
                return BadRequest("Country With id " + allGuestInfoDTO.NationalityCountryID + " Not Found !");



            clsGuest Guest = new clsGuest(new GuestDTO(-1,-1,0,allGuestInfoDTO.CreatedByEmployeeID),
                new PersonDTO(-1,allGuestInfoDTO.NationalNo,(byte)Gender,allGuestInfoDTO.FirstName,allGuestInfoDTO.MidlleName,
                allGuestInfoDTO.LastName,allGuestInfoDTO.Email,allGuestInfoDTO.Phone,allGuestInfoDTO.Address,
                allGuestInfoDTO.DateOfBirth,allGuestInfoDTO.NationalityCountryID));

            if (!Guest.Save())
                return StatusCode(500, "Error Add Guest");

            allGuestInfoDTO.GuestID = Guest.GuestID;
            allGuestInfoDTO.PersonID= Guest.PersonID;

            return CreatedAtRoute("GetGuestByID", new { GuestID = allGuestInfoDTO.GuestID }, allGuestInfoDTO);


        }


        [HttpPut("UpdateGuest/{GuestID}", Name = "UpdateGuest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AllGuestInfoDTO> UpdateGuest(int GuestID, AllGuestInfoDTO allGuestInfoDTO,clsPerson.enGender gender)
        {
            if (allGuestInfoDTO == null||GuestID<1 ||allGuestInfoDTO.PersonID<1|| allGuestInfoDTO.CreatedByEmployeeID < 1 || string.IsNullOrEmpty(allGuestInfoDTO.NationalNo) ||
                string.IsNullOrEmpty(allGuestInfoDTO.FirstName) || string.IsNullOrEmpty(allGuestInfoDTO.LastName) ||
                string.IsNullOrEmpty(allGuestInfoDTO.Phone) || !clsValidation.ValidateInteger(Convert.ToString(allGuestInfoDTO.Phone))
                || allGuestInfoDTO.NationalityCountryID < 1
                )
                return BadRequest("Invalid Guest Data !");

            clsGuest Guest = clsGuest.FindByGuestID(GuestID);

            if (Guest == null)
                return NotFound("Guest With ID : " + GuestID + " Not Found !");


           


            if ( Guest.Email!=allGuestInfoDTO.Email&& !string.IsNullOrEmpty(allGuestInfoDTO.Email) && !clsValidation.ValidateEmail(allGuestInfoDTO.Email))
                return BadRequest("Email " + allGuestInfoDTO.Email + " Not Valide");



            if (Guest.NationalNo!=allGuestInfoDTO.NationalNo&& clsGuest.IsGuestExistForNationalNo(allGuestInfoDTO.NationalNo))
                return BadRequest("National No : " + allGuestInfoDTO.NationalNo + " Already exist");


            if (Guest.CreatedByEmployeeID!=allGuestInfoDTO.CreatedByEmployeeID&& !clsEmployee.IsEmployeeExist(allGuestInfoDTO.CreatedByEmployeeID))
                return NotFound("Employee With id : " + allGuestInfoDTO.CreatedByEmployeeID + " NotFound");


            if (Guest.NationalityCountryID != allGuestInfoDTO.NationalityCountryID && clsCountry.Find(allGuestInfoDTO.NationalityCountryID) == null)
                return BadRequest("Country With id " + allGuestInfoDTO.NationalityCountryID + " Not Found !");




           
            Guest.CreatedByEmployeeID=allGuestInfoDTO.CreatedByEmployeeID;
            Guest.NationalNo=allGuestInfoDTO.NationalNo;
            Guest.Gender=(byte)gender;
            Guest.FirstName=allGuestInfoDTO.FirstName;
            Guest.MidlleName=allGuestInfoDTO.MidlleName;
            Guest.LastName=allGuestInfoDTO.LastName;
            Guest.Email=allGuestInfoDTO.Email;
            Guest.Phone=allGuestInfoDTO.Phone;
            Guest.Address=allGuestInfoDTO.Address;
            Guest.NationalityCountryID=allGuestInfoDTO.NationalityCountryID;
            Guest.DateOfBirth=allGuestInfoDTO.DateOfBirth;
            




            if (!Guest.Save())
                return StatusCode(500, "Error Updating Guest");



            return Ok(Guest.allGuestInfoDTO);

        }

    }
}
