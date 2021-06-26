using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mosh_practice.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance; //將customr表單的驗證訊息轉換成customer type
            if (customer.MembershipTypeId == MembershipType.UnKnown || customer.MembershipTypeId == MembershipType.PayAsYouGo) //沒有選擇會員制度或選擇一般會員，則birthday欄位過關
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null) //假設選了其他會員制度，則必須要求會員的年紀大於18
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should at least 18 years old to go on a membership.");
        }
    }
}