using SearchApi.Models;

namespace SearchApi.Data
{
    public class Data
    {
        public static List<Person> People { get; } =
        [
            new Person
            {
                Id = 0,
                Name = "Alex",
                Phone = "+38098022",
                Skills = ["Dev", "DevOps"],
                Jobs =
                [
                    new Job { Position = "Dev", Years = 1 },
                    new Job { Position = "DevOps", Years = 2 }
                ]
            },
            new Person
            {
                Id = 1,
                Name = "Margo",
                Phone = "+11111111",
                Skills = ["Designer", "MotionDesigner"],
                Jobs =
                [
                    new Job { Position = "Dev", Years = 1 },
                    new Job { Position = "DevOps", Years = 2 }
                ]
            },
            new Person
            {
                Id = 2,
                Name = "Sasha",
                Phone = "+22222222",
                Skills = ["Dev", "DevOps"],
                Jobs =
                [
                    new Job { Position = "Dev", Years = 1 },
                    new Job { Position = "DevOps", Years = 2 }
                ]
            }
        ];
    }
}
