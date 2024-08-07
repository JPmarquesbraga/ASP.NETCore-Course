using Assignment12.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Assignment12.Models
{
    public class Order
    {
        public int? OrderNum {  get; set; }


        [Required]
        [DateValidatorAttribute]
        public DateTime? OrderDate { get; set; }

        [Required]
        [TotalPriceProductValidator]
        public double? InvoicePrice { get; set; }

        [Required]
        [MinLength(1)]
        public List<Product> Products { get; set; }

        public void RandomOrderNum()
        {
            Random random = new Random();
            OrderNum = random.Next(1, 99999);
        }
        public override string ToString()
        {
            string productsValues = string.Empty;
            foreach (var item in Products) 
            {
                productsValues += item.ToString();
            }
            return $"OrderNumber: {OrderNum}\nInvoice Price: {InvoicePrice}\n{productsValues}";
        }
    }
}
