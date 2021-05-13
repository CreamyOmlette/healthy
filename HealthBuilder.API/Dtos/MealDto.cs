using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.API.Dtos
{
    public class MealDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string ImgSrc { get; set; }
        
        [Required]
        public int Calories { get; set; }
        
        [Required]
        public int Proteins { get; set; }
        
        [Required]
        public int Carbohydrates { get; set; }
        
        [Required]
        public int Fats { get; set; }
    }
}