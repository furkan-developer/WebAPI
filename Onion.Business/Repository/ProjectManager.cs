using AutoMapper;
using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Models;
using Onion.Shared.DataTransferObject;
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
        private readonly IMapper _mapper;

        public ProjectManager(IRepositoryManager projectRepository, ILoggerService loggerService,IMapper mapper)
        {
            this._repositoryManager = projectRepository;
            this._loggerService = loggerService;
            this._mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAll(bool trackChange)
        {
            try
            {
                var result = _repositoryManager.ProjectRepository.GetAllProjects(false);
                return result.Select(pro => _mapper.Map<ProjectDto>(pro));
            }
            catch (Exception ex)
            {
                _loggerService.LogError("ProjectManager.GetAll() has an error: " + ex.Message);
                throw;
            }
        }

        public ProjectDto GetOneProjectByProjectId(Guid id, bool trackChange)
        {
            try
            {
                var project = _repositoryManager.ProjectRepository.GetOneProjectByProjectId(id, trackChange);
                return _mapper.Map<ProjectDto>(project); 
            }
            catch (Exception ex)
            {
                _loggerService.LogError("ProjectManager.GetOneProjectByProjectId() has an error: "
                    + ex.Message);
                throw;
            }
        }
    }
}
