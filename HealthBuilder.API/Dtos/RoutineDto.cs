using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.API.Dtos
{
    public class RoutineDto
    {
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public string Reps { get; set; }
        public string Sets { get; set; }
        public int Duration { get; set; }
    }
}