using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SoftwareApp.DataTransferObjects;
using SoftwareApp.IBusinessLogic;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SoftwareApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ISoftwareBI softwareBI;
        public LocationController(ISoftwareBI _softwareBI)
        {
            softwareBI = _softwareBI;
        }

        [HttpGet("GetAllLocations")]
        [ProducesResponseType(typeof(ActionResult<IList<PlatformDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<PlatformDTO>>> GetAllLocations()
        {
            var locations = await softwareBI.GetAllLocations();

            return await Task.Run(() => Ok(locations));
        }

        [HttpPost("AddLocation")]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PostLocation(LocationDTO locationDTO)
        {
            var result = await softwareBI.SaveLocation(locationDTO);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteLocation(int id)
        {
            var result = await softwareBI.DeleteLocationById(id);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }
    }
}
