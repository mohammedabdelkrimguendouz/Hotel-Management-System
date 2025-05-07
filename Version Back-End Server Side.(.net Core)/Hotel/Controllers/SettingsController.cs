using Hotel_Buisness;
using Hotel_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/clsSettings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet("GetFoodPrice", Name = "GetFoodPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<float> GetFoodPrice()
        {
            return Ok(clsSetting.GetFoodPrice());

        }
    }
}
