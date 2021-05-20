using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class PasswordDto
    {
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Your password must contain a lower case, upper case and a special character")]
        public string Password { get; set; }
    }
}