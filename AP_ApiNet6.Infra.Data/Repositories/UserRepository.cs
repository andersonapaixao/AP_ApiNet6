using AP_ApiNet6.Domain.Entities;
using AP_ApiNet6.Domain.Repositories;
using AP_ApiNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users
                .Include(x => x.UserPermissions).ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);    
        }
    }
}
