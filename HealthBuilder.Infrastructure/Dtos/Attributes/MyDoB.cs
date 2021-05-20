using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos.Attributes
{
    public class MyDoBAttribute : ValidationAttribute
    {
            public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
            {
                DateTime d = Convert.ToDateTime(value);
                return d < DateTime.Now; //Dates Less than or equal to today are valid (true)
            }
    }
    
}