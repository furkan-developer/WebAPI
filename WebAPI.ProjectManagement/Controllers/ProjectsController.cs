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
        private readonly IRepositoryManager _rp;
        private readonly ILoggerService loggerService;

        public ProjectsController(ILoggerService loggerService,IRepositoryManager repositoryManager)
        {
            this.loggerService = loggerService;
            this._rp = repositoryManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                loggerService.LogInfo("Projects.Get() has been run");
                return Ok(_rp.ProjectRepository.GetAllProjects(false));
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
