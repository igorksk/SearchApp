namespace SearchApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string[] Skills { get; set; } = [];
        public List<Job> Jobs { get; set; } = [];
    }
}
