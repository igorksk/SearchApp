using AutoMapper;
using SearchApi.Dtos;
using SearchApi.Models;

namespace SearchApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Jobs, opt => opt.MapFrom(src => src.Jobs));

            CreateMap<PersonDto, Person>()
                .ForMember(dest => dest.Jobs, opt => opt.MapFrom(src => src.Jobs));

            CreateMap<Job, JobDto>();
            CreateMap<JobDto, Job>();
        }
    }
}
