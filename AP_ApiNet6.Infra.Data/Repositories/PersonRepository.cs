using AP_ApiNet6.Domain.Entities;
using AP_ApiNet6.Domain.FiltersDb;
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
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;  
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
        {
            var people = _db.People.AsQueryable();
            if(!string.IsNullOrEmpty(request.Name))
                people = people.Where(x => x.Name.Contains(request.Name));

            return await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}
