using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.API.Dtos
{
    public class ScheduledRoutineDto
    {
        [Required]
        public RoutineDto Routine { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}