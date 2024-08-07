using Assignment12.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Assignment12.CustomValidators
{
    public class TotalPriceProductValidatorAttribute : ValidationAttribute
    {
        public double InvoicePrice {  get; set; }
        public string DefaultErrorMessage { get; set; } = "InvoicePrice doesn't match with the total cost of the specified products in the order.";
     

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var order = validationContext.ObjectInstance as Order;

                double soma = 0;
                foreach (var item in order.Products)
                {
                    soma += item.Price.GetValueOrDefault() * item.Quantity.GetValueOrDefault();
                }

                if (soma != order.InvoicePrice.GetValueOrDefault())
                {
                    return new ValidationResult(DefaultErrorMessage);
                }

            }

            return ValidationResult.Success;
        }
    }
}
