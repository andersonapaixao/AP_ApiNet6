using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Application.DTOs.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
        Task<ResultService<ICollection<ProductDTO>>> GetAsync();
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ProductDTO productDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
