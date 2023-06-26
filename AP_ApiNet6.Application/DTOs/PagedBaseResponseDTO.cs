using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public PagedBaseResponseDTO(int totalRegoster, List<T> data)
        {
            TotalRegoster = totalRegoster;
            Data = data;
        }

        public int TotalRegoster { get; private set; }
        public List<T> Data { get; private set; }
    }
}
