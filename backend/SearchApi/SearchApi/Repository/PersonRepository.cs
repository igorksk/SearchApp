using Microsoft.EntityFrameworkCore;
using SearchApi.Data;
using SearchApi.Models;

namespace SearchApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleDbContext _context;

        public PersonRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPeopleByNameStart(string name)
        {
            return await _context.People
                .Include(p => p.Jobs)
                .Where(p => EF.Functions.Like(p.Name.ToLower(), name.ToLower() + "%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _context.People.Include(p => p.Jobs).ToListAsync();
        }

        public async Task<Person> AddPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> RemovePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
                return false;

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
