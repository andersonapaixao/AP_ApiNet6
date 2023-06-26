using AP_ApiNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Repositories
{
    public  interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<ICollection<Product>> GetProductAsync();
        Task<Product> CreateAsync(Product product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
        Task<int> GetIdByCodErpAsync(string codErp);
    }
}
