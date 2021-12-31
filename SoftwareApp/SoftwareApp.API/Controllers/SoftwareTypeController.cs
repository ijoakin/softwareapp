using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareApp.DataTransferObjects;
using SoftwareApp.IBusinessLogic;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SoftwareApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareTypeController : ControllerBase
    {
        private readonly ISoftwareBI softwareBI;
        public SoftwareTypeController(ISoftwareBI _softwareBI)
        {
            softwareBI = _softwareBI;
        }

        [HttpGet("GetAllSoftwareTypes")]
        [ProducesResponseType(typeof(ActionResult<IList<SoftwareTypeDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<SoftwareTypeDTO>>> GetAllSoftwareTypes()
        {
            var results = await softwareBI.GetAllSoftwareTypes();


            return await Task.Run(() => Ok(results));
        }

        [HttpPost("AddSoftwareType")]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PostSoftwareType(SoftwareTypeDTO softwareTypeDTO)
        {
            var result = await softwareBI.SaveSoftwareType(softwareTypeDTO);
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
            var result = await softwareBI.DeleteSoftwareTypeById(id);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }
    }
}
