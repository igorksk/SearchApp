namespace SearchApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<Data.Data>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/people", () => Data.Data.People);

            app.MapGet("/people/{name}", (string name) =>
            {
                var filteredPeople = Data.Data.People.Where(p => p.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
                return filteredPeople.Any() ? Results.Ok(filteredPeople) : Results.NotFound();
            });

            app.Run();
        }
    }
}
