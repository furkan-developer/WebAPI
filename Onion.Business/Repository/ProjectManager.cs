using AutoMapper;
using Onion.Business.Contracts;
using Onion.Contrants;
using Onion.Entities.Exceptions;
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

        public ProjectManager(IRepositoryManager projectRepository, ILoggerService loggerService, IMapper mapper)
        {
            this._repositoryManager = projectRepository;
            this._loggerService = loggerService;
            this._mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAll(bool trackChange)
        {
            var result = _repositoryManager.ProjectRepository.GetAllProjects(false);
            return result.Select(pro => _mapper.Map<ProjectDto>(pro));
        }

        public ProjectDto GetOneProjectByProjectId(Guid id, bool trackChange)
        {           
            var project = _repositoryManager.ProjectRepository.GetOneProjectByProjectId(id, trackChange);
            if(project is null)
                throw new ProjectNotFoundException(id);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}
