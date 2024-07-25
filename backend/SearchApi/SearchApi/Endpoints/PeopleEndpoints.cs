using SearchApi.Services;

namespace SearchApi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void MapEndpoints(WebApplication app)
        {
            app.MapGet("/people", async (IPersonService peopleService) =>
            {
                var people = await peopleService.GetAllPeople();
                return Results.Ok(people);
            });

            app.MapGet("/people/{name}", async (IPersonService peopleService, string name) =>
            {
                var filteredPeople = await peopleService.GetPeopleByNameStart(name);
                return Results.Ok(filteredPeople);
            });
        }
    }
}
