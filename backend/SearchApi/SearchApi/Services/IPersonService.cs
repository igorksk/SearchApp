using SearchApi.Dtos;

namespace SearchApi.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllPeople();

        Task<IEnumerable<PersonDto>> GetPeopleByNameStart(string name);

        Task<PersonDto> AddPerson(PersonDto personDto);

        Task<bool> RemovePerson(int id);
    }
}
