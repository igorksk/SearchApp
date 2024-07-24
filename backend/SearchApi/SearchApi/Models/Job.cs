using System.Text.Json.Serialization;

namespace SearchApi.Models
{
    public class Job
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public int Years { get; set; }

        [JsonIgnore]
        public int PersonId { get; set; }

        [JsonIgnore]
        public Person Person { get; set; } = new Person();
    }
}
