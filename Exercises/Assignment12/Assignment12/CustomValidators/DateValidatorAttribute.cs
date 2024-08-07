using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Assignment12.CustomValidators
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        public DateTime? Date { get; set; }
        public string DefaultErrorMessage { get; set; } = "The OrderDate Value is not valid";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //DateTime? date = (DateTime)value;
                var dateString = value.ToString();
                DateTime dateTime;
                bool isValid = DateTime.TryParseExact(
                    dateString,
                    "yyyy-MM-ddTHH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateTime);

                if (isValid)
                {
                    return new ValidationResult(DefaultErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
