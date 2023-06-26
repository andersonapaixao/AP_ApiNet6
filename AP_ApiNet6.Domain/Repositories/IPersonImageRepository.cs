using AP_ApiNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Repositories
{
    public interface IPersonImageRepository
    {
        Task<PersonImage> GetByIdAsync(int id);
        Task<PersonImage> CreateAsync(PersonImage personImage);
        Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
        Task EditAsync(PersonImage personImage);
    }
}
