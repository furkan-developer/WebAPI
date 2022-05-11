using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Entities.Models;

namespace Onion.WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly List<Project> projects;
        private readonly ILogger<ProjectsController> logger;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            this.logger = logger;
            projects = new List<Project>
            {
                new Project { Id = Guid.NewGuid(), Name = "project 1"},
                new Project { Id = Guid.NewGuid(), Name = "project 2"}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                logger.LogInformation("Projects.Get() has been run");
                return Ok(projects);
            }
            catch (Exception ex)
            {
                logger.LogError("Project.Get() has been crashed!"+ex.Message);
                return BadRequest(ex.Message);

                throw;
            }
        }
    }
}
