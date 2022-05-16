using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Contrants
{
    public interface IEmployeeReository
    {
        //contract of the depend entity
        IEnumerable<Employee> GetEmployeesByProjectId(Guid projectId, bool trackChanges);
        Employee GetEmployeeByProjectId(Guid projectId, Guid id, bool trackChanges);


        //oluşturulan employee bir projede olacağından "CreateEmployeeForProject" denildi.
        //bu da aslında depend entity olduğunu gösterir.
        void CreateEmployeeForProject(Guid projectId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
