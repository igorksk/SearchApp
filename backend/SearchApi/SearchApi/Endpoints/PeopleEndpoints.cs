using Microsoft.AspNetCore.Mvc;
using SearchApi.Dtos;
using SearchApi.Services;

namespace SearchApi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/api/people", async (IPersonService service) =>
            {
                var people = await service.GetAllPeople();
                return Results.Ok(people);
            });

            app.MapGet("/api/people/search", async (string name, IPersonService service) =>
            {
                var people = await service.GetPeopleByNameStart(name);
                return Results.Ok(people);
            });

            app.MapPost("/api/people", async (PersonDto person, IPersonService service) =>
            {
                var addedPerson = await service.AddPerson(person);
                return Results.Created($"/api/people/{addedPerson.Id}", addedPerson);
            });

            app.MapDelete("/api/people/{id}", async (int id, IPersonService service) =>
            {
                var result = await service.RemovePerson(id);
                if (!result)
                    return Results.NotFound();
                return Results.NoContent();
            });
        }
    }
}
