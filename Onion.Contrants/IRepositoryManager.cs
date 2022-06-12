using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Contrants
{
    public interface IRepositoryManager
    {
        IProjectRepository ProjectRepository { get; }
        IEmployeeReository  EmployeeReository { get; }
        void Save();
    }
}
