using AP_ApiNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> CreateAsync(Purchase purchase);
        Task<Purchase> GetByIdAsync(int id);
        Task<ICollection<Purchase>> GetAllAsync();
        
        Task EditAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
        Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
        Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
    }
}
