using System.ComponentModel.DataAnnotations;

namespace Assignment12.Models
{
    public class Product
    {
        [Required]
        public int? ProductCode {  get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public override string ToString()
        {
            return $"Product Code: {ProductCode}\nProduct Price: {Price}\nProduct Quantity: {Quantity}\n";
        }
    }
}
