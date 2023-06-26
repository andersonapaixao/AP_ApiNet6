using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
