using Microsoft.EntityFrameworkCore;
using SearchApi.Data;
using SearchApi.Endpoints;
using SearchApi.Helpers;
using SearchApi.Repository;
using SearchApi.Services;

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

            builder.Services.AddDbContext<PeopleDbContext>(options =>
            {
                options.UseInMemoryDatabase("SearchDb");
            });

            builder.Services.AddTransient<PeopleDataSeeder>();
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IPersonService, PersonService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PeopleDbContext>();
                var dataSeeder = services.GetRequiredService<PeopleDataSeeder>();
                dataSeeder.Seed();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyCorsPolicy");

            PeopleEndpoints.MapEndpoints(app);

            app.Run();
        }
    }
}
