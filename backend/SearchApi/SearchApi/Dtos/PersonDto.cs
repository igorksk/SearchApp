namespace SearchApi.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string[] Skills { get; set; } = [];
        public List<JobDto> Jobs { get; set; } = [];
    }
}
