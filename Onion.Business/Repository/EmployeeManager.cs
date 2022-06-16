using AutoMapper;
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
        private readonly IMapper _mapper;

        public EmployeeManager(IRepositoryManager repositoryManager
            , ILoggerService loggerService,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChange)
        {
            try
            {
                var result = _repositoryManager
                    .EmployeeReository
                    .GetEmployeesByProjectId(projectId, trackChange);
                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(result);
                return employeesDto;
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
                return _mapper.Map<EmployeeDto>(result);
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
