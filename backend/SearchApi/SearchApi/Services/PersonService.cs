using AutoMapper;
using SearchApi.Dtos;
using SearchApi.Models;
using SearchApi.Repository;

namespace SearchApi.Services
{
    public class PersonService(IMapper mapper, IPersonRepository repo) : IPersonService
    {
        private readonly IMapper _mapper = mapper;

        private readonly IPersonRepository _repo = repo;

        public async Task<IEnumerable<PersonDto>> GetAllPeople()
        {
            var people = await _repo.GetAllPeople();
            return ConvertToPersonDtos(people);
        }

        public async Task<IEnumerable<PersonDto>> GetPeopleByNameStart(string name)
        {
            var people = await _repo.GetPeopleByNameStart(name);
            return ConvertToPersonDtos(people);
        }

        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            var addedPerson = await _repo.AddPerson(person);
            return _mapper.Map<PersonDto>(addedPerson);
        }

        public async Task<bool> RemovePerson(int id)
        {
            return await _repo.RemovePerson(id);
        }

        private IEnumerable<PersonDto> ConvertToPersonDtos(IEnumerable<Person> people)
        {
            return _mapper.Map<IEnumerable<PersonDto>>(people);
        }
    }
}
