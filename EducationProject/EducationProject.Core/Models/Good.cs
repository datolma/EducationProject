namespace EducationProject.Core
{
    public class Good
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Price { get; set; }
        public string? Description {  get; set; }
        public int Count { get; set; }
    }
}
