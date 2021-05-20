using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class RoutineDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Difficulty { get; set; }
        public int Duration { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}