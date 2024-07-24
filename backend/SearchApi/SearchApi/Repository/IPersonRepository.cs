using SearchApi.Models;

namespace SearchApi.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeopleByNameStart(string name);
        Task<IEnumerable<Person>> GetAllPeople();
    }
}
