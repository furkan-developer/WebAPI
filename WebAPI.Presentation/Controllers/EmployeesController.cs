using Microsoft.AspNetCore.Mvc;
using Onion.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllEmployeesByProjectId(Guid projectId)
        {
            var result = _serviceManager
                .EmployeeService
                .GetAllEmployeesByProjectId(projectId, false);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOneEmployeeByProjectId(Guid projectId, Guid id)
        {
            var result = _serviceManager
                .EmployeeService
                .GetOneEmployeeByProjectId(projectId, id, false);
            return Ok(result);
        }
    }
}
