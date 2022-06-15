using Onion.Entities.Models;

namespace Onion.Business.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId,bool trackChange);
        Employee GetOneEmployeeByProjectId(Guid projectId,Guid employeeId, bool trackChange);
    }
}
