using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Models;
using Onion.Shared.DataTransferObject;

namespace Onion.Business.Repository
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerService _loggerService;

        public EmployeeManager(IRepositoryManager repositoryManager, ILoggerService loggerService)
        {
            _repositoryManager = repositoryManager;
            _loggerService = loggerService;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChange)
        {
            try
            {
                var result = _repositoryManager
                    .EmployeeReository
                    .GetEmployeesByProjectId(projectId, trackChange);
                return result.Select(emp => 
                    new EmployeeDto(emp.Id, emp.FirstName, emp.LastName, emp.Age, emp.Position));
            }
            catch (Exception ex)
            {
                _loggerService.LogError("EmployeeManager.GetAllEmployeesByProjectId() has an error: "
                    + ex.Message);
                throw;
            }
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChange)
        {
            try
            {
                var result = _repositoryManager
                    .EmployeeReository
                    .GetEmployeeByProjectId(projectId, employeeId, trackChange);
                return new EmployeeDto(
                    result.Id, result.FirstName, result.LastName, result.Age,result.Position);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("EmployeeManager.GetOneEmployeeByProjectId() has an error: "
                    + ex.Message);
                throw;
            }
        }
    }
}
