using DVLD_DataAccess;
using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/Countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet("GetAllCountries", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CountryDTO>> GetAllCountries()
        {
            List<CountryDTO> CountriesList = clsCountry.GetAllCountries();

            if (CountriesList.Count == 0)
                return NotFound("Not  Countries Found !");

            return Ok(CountriesList);
        }



        [HttpGet("GetCountryByID/{CountryID}", Name = "GetCountryByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CountryDTO> GetCountryByID(int CountryID)
        {
            if (CountryID < 1)
                return BadRequest("Not Accepted ID : " + CountryID);

            clsCountry Country = clsCountry.Find(CountryID);

            if (Country == null)
                return NotFound("Country With ID : " + CountryID + " Not Found !");

            return Ok(Country.countryDTO);

        }




        [HttpGet("GetCountryByName/{CountryName}", Name = "GetCountryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CountryDTO> GetCountryByName(string CountryName)
        {

            clsCountry Country = clsCountry.Find(CountryName);

            if (Country == null)
                return NotFound("Country With  CountryName : " + CountryName + " Not Found !");

            return Ok(Country.countryDTO);

        }
    }
}
