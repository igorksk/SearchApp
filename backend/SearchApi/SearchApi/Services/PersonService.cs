using AutoMapper;
using SearchApi.Dtos;
using SearchApi.Models;
using SearchApi.Repository;

namespace SearchApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;

        private readonly IPersonRepository _repo;

        public PersonService(IMapper mapper, IPersonRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPeople()
        {
            var people = await _repo.GetAllPeople();
            return ConvertToPersonDtos(people); ;
        }

        public async Task<IEnumerable<PersonDto>> GetPeopleByNameStart(string name) 
        {
            var people =  await _repo.GetPeopleByNameStart(name);
            return ConvertToPersonDtos(people);
        }

        private IEnumerable<PersonDto> ConvertToPersonDtos(IEnumerable<Person> people)
        {
            return _mapper.Map<IEnumerable<PersonDto>>(people);
        }
    }
}
