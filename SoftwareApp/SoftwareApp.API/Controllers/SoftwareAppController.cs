using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SoftwareApp.DataAccess;
using SoftwareApp.DataTransferObjects;
using SoftwareApp.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SoftwareApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareAppController : ControllerBase
    {
        private readonly ISoftwareBI softwareBI;
        private readonly IConfiguration configuration;
        public SoftwareAppController(ISoftwareBI _softwareBI, IConfiguration _configuration)
        {
            this.softwareBI = _softwareBI ?? throw new ArgumentNullException(nameof(_softwareBI));
            this.configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }

        [HttpGet("GetSoftware")]
        [ProducesResponseType(typeof(IList<SoftwareDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<SoftwareDTO>>> GetSoftware(string name, int typeId)
        {
            var list = await softwareBI.GetAllSoftwares(name, typeId);

            return Ok(list);
        }

        [HttpGet("GetSoftware/{name}")]
        [ProducesResponseType(typeof(IList<SoftwareDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<SoftwareDTO>>> GetSoftware(string name)
        {
            var list = await softwareBI.GetAllSoftwares(name);

            if (list.Count > 0) return Ok(list);

            return NotFound();
        }

        [HttpGet("GetAllSoftwares")]
        [ProducesResponseType(typeof(IList<SoftwareDTO>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<SoftwareDTO>>> GetAllSoftwares()
        {
            var list = await softwareBI.GetAllSoftwares( "", 0);

            if (list.Count > 0) return Ok(list);

            return NotFound();
        }
        [HttpGet("GetAllSoftwaresDapper")]
        [ProducesResponseType(typeof(IList<SoftwareDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<IList<SoftwareDTO>> GetAllSoftwaresDapper()
        {
            var connectionString = configuration.GetConnectionString("SoftwareConnection");
            DapperTest dapperTest = new DapperTest(connectionString);

            var list = dapperTest.GetSoftwaresDapper();

            if (list.Count > 0) return Ok(list);

            return NotFound();
        }

        [HttpGet("GetSoftwareById/{id}")]
        [ProducesResponseType(typeof(SoftwareDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SoftwareDTO>> GetSoftwareById(int id)
        {
            var software = await softwareBI.GetSoftwaresById(id);

            if (software != null) return Ok(software);

            return NotFound();
        }

        [HttpDelete("DeleteSoftwareById/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> DeleteSoftwareById(int id)
        {
            var result = await softwareBI.DeleteSoftwareById(id);

            if (result) return Ok(result);

            return NotFound();
        }

        [HttpPost("SaveSoftware")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> SaveSoftware(SoftwareDTO softwareDTO)
        {
            var result = await softwareBI.SaveSoftware(softwareDTO);

            if (result) return Ok(result);

            return NotFound();
        }

    }
}
