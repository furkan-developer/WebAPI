using AutoMapper;
using Onion.Entities.Models;
using Onion.Shared.DataTransferObject;

namespace Onion.WebAPI.Utilities.Mapping.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
