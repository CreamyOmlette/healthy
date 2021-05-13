using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.API.Dtos
{
    public class ScheduledMealDto
    {
        [Required] 
        public MealDto Meal { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public bool Status { get; set; }
    }
}