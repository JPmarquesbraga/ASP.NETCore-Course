﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute 
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";
        public MinimumYearValidatorAttribute() 
        {
                
        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= 2000)
                {
                    return new ValidationResult(string.Format(ErrorMessage ??
                    DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
