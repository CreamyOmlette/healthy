using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class ScheduledMealDto
    {
        public int? Id { get; set; }
        
        [Required] 
        public MealDto Meal { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public bool Status { get; set; }
    }
}