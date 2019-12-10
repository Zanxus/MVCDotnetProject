using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDotnetProject.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("18 years or over needed for current selected plan");
        }
    }
}