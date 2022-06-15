using Onion.Entities.Models;
using Onion.Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Business.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAll(bool trackChange);
        ProjectDto GetOneProjectByProjectId(Guid id, bool trackChange);
    }
}
