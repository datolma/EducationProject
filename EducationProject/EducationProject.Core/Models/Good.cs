using System.ComponentModel.DataAnnotations;

namespace EducationProject.Core.Models
{
    public class Good
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description {  get; set; }
        public int Count { get; set; }

        public int Discount { get; set; } = 0;

        public decimal FinalPrice                   // ← decimal
        {
            get
            {
                if (Discount <= 0) return Price;
                return Price - (Price * Discount / 100);
            }
        }
    }
}
