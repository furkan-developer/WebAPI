using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Contrants;
using Onion.Entities.Models;

namespace Onion.WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly List<Project> projects;
        private readonly ILoggerService loggerService;

        public ProjectsController(ILoggerService loggerService)
        {
            this.loggerService = loggerService; //Dependency Injection 
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
                loggerService.LogInfo("Projects.Get() has been run");
                return Ok(projects);
            }
            catch (Exception ex)
            {
                loggerService.LogError("Project.Get() has been crashed!"+ex.Message);
                return BadRequest(ex.Message);

                throw;
            }
        }
    }
}
