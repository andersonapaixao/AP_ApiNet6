using AP_ApiNet6.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.Services.Interfaces
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO);
        Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO);
    }
}
