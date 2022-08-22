using System.ComponentModel.DataAnnotations;

namespace ServiceRepositoryPattern.Models
{
    public class FoodItem
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Profit
        {
            get
            {
                return (SalePrice * Quantity) - (UnitPrice * Quantity);
            }
        }
    }
}
