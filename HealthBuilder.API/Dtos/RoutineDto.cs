using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.API.Dtos
{
    public class RoutineDto
    {
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
    }
}