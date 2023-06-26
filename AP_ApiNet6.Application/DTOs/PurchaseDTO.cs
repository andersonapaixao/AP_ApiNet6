using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string CodErp { get; set; }
        public string Document { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}
