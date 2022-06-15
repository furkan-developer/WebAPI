﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Business.Contracts
{
    public interface IServiceManager
    {
        IProjectService ProjectService { get; }
        IEmployeeService EmployeeService { get; }
    }
}
