using AutoMapper;
using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Exceptions;
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
            , ILoggerService loggerService, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChange)
        {
            CheckProjectExist(projectId);

            var result = _repositoryManager
               .EmployeeReository
               .GetEmployeesByProjectId(projectId, trackChange);
            if (result is null)
                throw new EmployeeNotFoundException();

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(result);
            return employeesDto;
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChange)
        {
            CheckProjectExist(projectId);

            var result = _repositoryManager
                .EmployeeReository
                .GetEmployeeByProjectId(projectId, employeeId, trackChange);
            if(result is null)
              throw new EmployeeNotFoundException(employeeId);

            return _mapper.Map<EmployeeDto>(result);
        }

        #region Check
        public void CheckProjectExist(Guid projectId)
        {
            var project = _repositoryManager
                .ProjectRepository
                .GetOneProjectByProjectId(projectId, trackChanges: false);
            if (project is null)
                throw new ProjectNotFoundException(projectId);
        }
        #endregion
    }
}
