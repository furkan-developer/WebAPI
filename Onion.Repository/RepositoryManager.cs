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
        private readonly Lazy<IProjectRepository> _projectRepository;
        private readonly Lazy<IEmployeeReository> _employeeReository;
        public RepositoryManager(RepositoryContext rpContext)
        {
            this.rpContext = rpContext;
            _projectRepository = new Lazy<IProjectRepository>(() => new ProjectRepository(rpContext));
            _employeeReository = new Lazy<IEmployeeReository>(() => new EmployeeRepository(rpContext));
        }

        public IProjectRepository ProjectRepository => _projectRepository.Value;

        public IEmployeeReository EmployeeReository => _employeeReository.Value;

        public void Save()
        {
            rpContext.SaveChanges();
        }
    }
}
