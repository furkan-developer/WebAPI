using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Business.Contracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll(bool trackChange);
        Project GetOneProjectByProjectId(Guid id, bool trackChange);
    }
}
