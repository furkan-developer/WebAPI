using Onion.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext rpContext;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeReository _employeeReository;
        public RepositoryManager(RepositoryContext rpContext)
        {
            this.rpContext = rpContext;
            _projectRepository = new ProjectRepository(rpContext);
            _employeeReository = new EmployeeRepository(rpContext);
        }

        public IProjectRepository ProjectRepository => _projectRepository;

        public IEmployeeReository EmployeeReository => _employeeReository;

        public void Save()
        {
            rpContext.SaveChanges();
        }
    }
}
