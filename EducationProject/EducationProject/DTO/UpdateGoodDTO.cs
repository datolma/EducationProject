namespace EducationProject.API.DTO
{
    public class UpdateGoodDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
    }
}
