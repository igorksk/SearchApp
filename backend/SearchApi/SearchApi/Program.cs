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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Replace with your allowed origins
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyCorsPolicy");

            app.MapGet("/people", () => Data.Data.People);

            app.MapGet("/people/{name}", (string name) =>
            {
                var filteredPeople = Data.Data.People.Where(p => p.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
                return Results.Ok(filteredPeople);
            });

            app.Run();
        }
    }
}
