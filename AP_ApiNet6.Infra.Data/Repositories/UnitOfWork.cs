using AP_ApiNet6.Domain.Repositories;
using AP_ApiNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _Transaction;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task BeginTransaction()
        {
            _Transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _Transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _Transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _Transaction?.Dispose();
        }

    }
}
