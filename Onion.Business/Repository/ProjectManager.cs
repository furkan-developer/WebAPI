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
            try
            {
                var result = _repositoryManager.ProjectRepository.GetAllProjects(false);
                return result;
            }
            catch (Exception ex)
            {
                _loggerService.LogError("ProjectManager.GetAll() has an error: " + ex.Message);
                throw;
            }
        }
    }
}
