using System.ComponentModel.DataAnnotations;
using HealthBuilder.Infrastructure.Exceptions;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class RegistrationModel
    {
        public string Username { get; set; }
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Your password must contain a lower case, upper case and a special character " +
                           "and be longer that 8 symbols")]
        public string Password { get; set; }
    }
}