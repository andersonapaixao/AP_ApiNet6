using AP_ApiNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Document { get;  set; }
        public string Phone { get;  set; }

    }
}
