﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationExample.CustomValidators;
using System.ComponentModel.DataAnnotations;
namespace ModelValidationExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} cant be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string? PersonName { get; set; }


        [EmailAddress(ErrorMessage = "{0} should be a propre email address")]
        [Required(ErrorMessage = "{0} cant be blank")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} cant be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} cant be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(2005, ErrorMessage = "Date of birth should not be newer than jan 01, {0}")]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidatorAttribute("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To date'")]
        public DateTime? ToDate { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}," +
                $"Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}
