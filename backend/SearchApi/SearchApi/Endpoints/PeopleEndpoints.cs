using SearchApi.Services;
using System.Xml.Linq;

namespace SearchApi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapGet("/people", () => Data.PeopleData.People);

            app.MapGet("/people/{name}", (string name) =>
            {
                var filteredPeople = PeopleService.FilterPeopleByName(Data.PeopleData.People, name);
                return Results.Ok(filteredPeople);
            });
        }
    }
}
