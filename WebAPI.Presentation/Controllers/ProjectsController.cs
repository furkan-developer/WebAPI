

using Microsoft.AspNetCore.Mvc;
using Onion.Business.Contracts;

namespace WebAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProjectsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var projects = _serviceManager.ProjectService.GetAll(false);
            return Ok(projects);
        }
        
        [HttpGet("{id:guid}")]
        public IActionResult GetOneProjectById(Guid id)
        {
            var project = _serviceManager.ProjectService.GetOneProjectByProjectId(id, false);
            return Ok(project);
        }
    }
} 
