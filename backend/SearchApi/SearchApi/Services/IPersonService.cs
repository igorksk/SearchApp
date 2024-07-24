using SearchApi.Models;

namespace SearchApi.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeople();

        Task<IEnumerable<Person>> GetPeopleByNameStart(string name);
    }
}
