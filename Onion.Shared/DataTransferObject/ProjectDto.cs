﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Shared.DataTransferObject
{
    public record ProjectDto(Guid Id,string Name,string Description,string Field);
}
