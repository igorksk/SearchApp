using SearchApi.Models;

namespace SearchApi.Data
{
    public class PeopleDataSeeder(PeopleDbContext context)
    {
        private readonly PeopleDbContext _context = context;

        public void Seed()
{
            if (!_context.People.Any())
            {
                _context.People.AddRange(
                    new Person
                    {
                        Id = 1,
                        Name = "Elena Petrova",
                        Phone = "+380671234567",
                        Skills = ["Software Development", "C#", ".NET", "SQL"],
                        Jobs =
                        [
                            new Job { Position = "Junior Developer", Years = 2 },
                            new Job { Position = "Software Developer", Years = 3 }
                        ]
                    },
                    new Person
                    {
                        Id = 2,
                        Name = "Dmytro Kovalenko",
                        Phone = "+380509876543",
                        Skills = ["Project Management", "Agile", "Scrum", "Jira"],
                        Jobs =
                        [
                            new Job { Position = "Project Coordinator", Years = 4 },
                            new Job { Position = "Project Manager", Years = 2 }
                        ]
                    },
                    new Person
                    {
                        Id = 3,
                        Name = "Olga Sydorenko",
                        Phone = "+380932345678",
                        Skills = ["UX Design", "UI Design", "Figma", "Adobe XD"],
                        Jobs =
                        [
                            new Job { Position = "Junior Designer", Years = 1 },
                            new Job { Position = "UX/UI Designer", Years = 3 }
                        ]
                    },
                    new Person
                    {
                        Id = 4,
                        Name = "Andriy Melnyk",
                        Phone = "+380958765432",
                        Skills = ["Data Analysis", "Python", "Pandas", "Machine Learning"],
                        Jobs =
                        [
                            new Job { Position = "Data Analyst", Years = 3 },
                            new Job { Position = "Data Scientist", Years = 1 }
                        ]
                    },
                    new Person
                    {
                        Id = 5,
                        Name = "Iryna Kravchenko",
                        Phone = "+380633456789",
                        Skills = ["Marketing", "Social Media", "SEO", "Content Creation"],
                        Jobs =
                        [
                            new Job { Position = "Marketing Assistant", Years = 2 },
                            new Job { Position = "Marketing Specialist", Years = 2 }
                        ]
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
