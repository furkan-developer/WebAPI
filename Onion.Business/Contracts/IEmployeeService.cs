using Onion.Entities.Models;
using Onion.Shared.DataTransferObject;

namespace Onion.Business.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId,bool trackChange);
        EmployeeDto GetOneEmployeeByProjectId(Guid projectId,Guid employeeId, bool trackChange);
    }
}
