using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class MealDto
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name of the meal is too long")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)")]
        public string ImgSrc { get; set; }
        
        [Required]
        [Range(0,1500)]
        public int Calories { get; set; }
        
        [Required]
        [Range(0,100)]
        public int Proteins { get; set; }
        
        [Required]
        [Range(0,100)]
        public int Carbohydrates { get; set; }
        
        [Required]
        [Range(0,100)]
        public int Fats { get; set; }
        
        [Required]
        [Range(0,10000)]
        public int Mass { get; set; }
    }
}