using Onion.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Contrants
{
    public interface IProjectRepository
    {
        //contract of the principle entity
        
        //bu repodan çıkan veri proje tarafından istenen veri yani veri tabanı işleri
        //bitmiş veri olacağından IQueryable bir veri değildir.
        IEnumerable<Project> GetAllProjects(bool trackChanges);
        Project GetProject(Guid id, bool trackChanges);

        void CreateProject(Project project);
        void DeleteProject(Project project);
    }
}
