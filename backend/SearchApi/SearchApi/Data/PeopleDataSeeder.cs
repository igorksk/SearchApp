using SearchApi.Models;

namespace SearchApi.Data
{
    public class PeopleDataSeeder
    {
        private readonly PeopleDbContext _context;

        public PeopleDataSeeder(PeopleDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.People.Any())
            {
                _context.People.AddRange(
                    new Person
                    {
                        Id = 1,
                        Name = "Alex",
                        Phone = "+38098022",
                        Skills = ["Dev", "DevOps"],
                        Jobs = new List<Job>
                        {
                            new Job { Position = "Dev", Years = 1 },
                            new Job { Position = "DevOps", Years = 2 }
                        }
                    },
                    new Person
                    {
                        Id = 2,
                        Name = "Margo",
                        Phone = "+11111111",
                        Skills = ["Designer", "MotionDesigner"],
                        Jobs = new List<Job>
                        {
                            new Job { Position = "Dev", Years = 1 },
                            new Job { Position = "DevOps", Years = 2 }
                        }
                    },
                    new Person
                    {
                        Id = 3,
                        Name = "Sasha",
                        Phone = "+22222222",
                        Skills = ["Dev", "DevOps"],
                        Jobs = new List<Job>
                        {
                            new Job { Position = "Dev", Years = 1 },
                            new Job { Position = "DevOps", Years = 2 }
                        }
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
