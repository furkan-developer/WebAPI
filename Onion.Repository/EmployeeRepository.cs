using Onion.Contrants;
using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeReository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeForProject(Guid projectId, Employee employee)
        {
            employee.ProjectId = projectId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployeeByProjectId(Guid projectId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.ProjectId.Equals(projectId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();
        

        public IEnumerable<Employee> GetEmployeesByProjectId(Guid projectId, bool trackChanges) =>
            FindByCondition(e => e.ProjectId.Equals(projectId), trackChanges)
            .OrderBy(e => e.FirstName)
            .ToList();

    }
}
