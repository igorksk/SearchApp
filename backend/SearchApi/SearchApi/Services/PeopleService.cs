using SearchApi.Models;

namespace SearchApi.Services
{
    public static class PeopleService
    {
        public static List<Person> FilterPeopleByName(List<Person> people, string name) 
        {
            return people.Where(p => p.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
