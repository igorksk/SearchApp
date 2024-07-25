namespace SearchApi.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public int Years { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = new Person();
    }
}
