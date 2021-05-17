using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Services.Dtos
{
    public class RoutineDto
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public int Duration { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}