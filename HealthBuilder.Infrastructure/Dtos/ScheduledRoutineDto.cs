using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class ScheduledRoutineDto
    {
        public int? Id { get; set; }
        [Required]
        public RoutineDto Routine { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}