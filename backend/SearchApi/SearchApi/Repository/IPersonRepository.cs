using SearchApi.Models;

namespace SearchApi.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeopleByNameStart(string name);
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person> AddPerson(Person person);
        Task<bool> RemovePerson(int id);
    }
}
