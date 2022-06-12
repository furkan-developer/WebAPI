using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Business.Repository
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProjectService> _projectService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService loggerService)
        {
            _projectService = new Lazy<IProjectService>(() => new ProjectManager(repositoryManager, loggerService));
        }

        public IProjectService ProjectService => _projectService.Value;
    }
}
