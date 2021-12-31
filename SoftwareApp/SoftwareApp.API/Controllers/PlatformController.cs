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
    public class PlatformController : ControllerBase
    {

        private readonly ISoftwareBI softwareBI;
        public PlatformController(ISoftwareBI _softwareBI)
        {
            softwareBI = _softwareBI;
        }

        [HttpGet("GetAllPlatforms")]
        [ProducesResponseType(typeof(ActionResult<IList<PlatformDTO>>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<PlatformDTO>>> GetAllPlatforms()
        {
            var platforms = await softwareBI.GetAllPlatforms();

            
            return await Task.Run(() => Ok(platforms));
        }

        [HttpPost("AddPlatform")]
        [ProducesResponseType(typeof (ActionResult<bool>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PostPlatform(PlatformDTO platformDTO)
        {
            var result = await softwareBI.SavePlatform(platformDTO);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }


        [HttpDelete]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeletePlatform(int id)
        {
            var result = await softwareBI.DeletePlatformById(id);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }
    }
}
