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

        public ProjectsController()
        {
            projects = new List<Project>
            {
                new Project { Id = Guid.NewGuid(), Name = "project 1"},
                new Project { Id = Guid.NewGuid(), Name = "project 2"}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return  Ok(projects);
        }
    }
}
