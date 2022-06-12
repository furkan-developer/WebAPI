using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Business.Repository
{
    public class ProjectManager : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerService _loggerService;

        public ProjectManager(IRepositoryManager projectRepository, ILoggerService loggerService)
        {
            this._repositoryManager = projectRepository;
            this._loggerService = loggerService;
        }

        public IEnumerable<Project> GetAll(bool trackChange)
        {
            if (true)
            {
                _loggerService.LogInfo("Data import completed successfully");
                return _repositoryManager.ProjectRepository.GetAllProjects(trackChange);
            }
            else
            {
                _loggerService.LogError("Data import unsuccessful");
                return null;
            }
        }
    }
}
