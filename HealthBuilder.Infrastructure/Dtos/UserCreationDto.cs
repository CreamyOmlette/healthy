using System;
using System.ComponentModel.DataAnnotations;
using HealthBuilder.Infrastructure.Dtos.Attributes;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class UserCreationDto
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Username must contain more than 4 symbols")]
        public string Username { get; set; }

        [Required]
        [Range(10,300, ErrorMessage = "Height is not valid")]
        public int Height { get; set; }
        
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Your password must contain a lower case, upper case and a special character")]
        public string Password { get; set; }
        
        [Required]
        [Range(10,250, ErrorMessage = "Weight is not valid")]
        public int Weight { get; set; }
        
        [Required]
        [MyDoB(ErrorMessage = "Date of birth is invalid")]
        public DateTime DoB { get; set; }
    }
    
}