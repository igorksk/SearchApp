using SearchApi.Models;
using SearchApi.Repository;

namespace SearchApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repo;

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _repo.GetAllPeople();
        }

        public async Task<IEnumerable<Person>> GetPeopleByNameStart(string name) 
        {
            return await _repo.GetPeopleByNameStart(name);
        }
    }
}
