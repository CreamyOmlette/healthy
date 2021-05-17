using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Services.Dtos
{
    public class UserDto
    {
        [Required]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Username must contain more than 4 symbols")]
        public string Username { get; set; }

        [Required]
        [Range(10,300, ErrorMessage = "Height is not valid")]
        public int Height { get; set; }
        
        [Required]
        [RegularExpression("[^a-zA-Z0-9]*$", ErrorMessage = "Your password must contain a lower case, upper case and a special character")]
        public string Password { get; set; }
        
        [Required]
        [Range(10,250, ErrorMessage = "Weight is not valid")]
        public int Weight { get; set; }
        
        [Required]
        [MyDoB(ErrorMessage = "Date of birth is invalid")]
        public DateTime DoB { get; set; }
    }
    public class MyDoBAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now; //Dates Less than or equal to today are valid (true)
        }
    }
}