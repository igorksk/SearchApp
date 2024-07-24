using Microsoft.EntityFrameworkCore;
using SearchApi.Models;

namespace SearchApi.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
            : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
            .HasOne(j => j.Person)
            .WithMany(p => p.Jobs)
            .HasForeignKey(j => j.PersonId);
        }
    }
}
