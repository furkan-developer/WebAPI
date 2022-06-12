using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Models;

namespace Onion.WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProjectsController(IServiceManager serviceManager)
        {        
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serviceManager.ProjectService.GetAll(false));            
        }
    }
}
