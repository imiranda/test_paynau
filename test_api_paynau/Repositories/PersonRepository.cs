using Microsoft.EntityFrameworkCore;
using test_api_paynau.Interfaces;
using test_api_paynau.Models;

namespace test_api_paynau.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly PaynauContext _dbContext;

        public PersonRepository(PaynauContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> AddAsync(Person entity)
        {
            _dbContext.Set<Person>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Person entity)
        {
            _dbContext.Persons.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.Persons.FindAsync(id);
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
