﻿using AutoMapper;
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
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService loggerService,IMapper mapper)
        {
            _projectService = new Lazy<IProjectService>(() => 
                new ProjectManager(repositoryManager, loggerService,mapper));
            _employeeService = new Lazy<IEmployeeService>(() =>
                new EmployeeManager(repositoryManager, loggerService,mapper));
        }

        public IProjectService ProjectService => _projectService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
