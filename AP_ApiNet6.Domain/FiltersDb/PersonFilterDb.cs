﻿using AP_ApiNet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.FiltersDb
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
    }
}
