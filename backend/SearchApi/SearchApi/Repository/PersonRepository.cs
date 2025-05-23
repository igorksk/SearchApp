﻿using Microsoft.EntityFrameworkCore;
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

    }
}
