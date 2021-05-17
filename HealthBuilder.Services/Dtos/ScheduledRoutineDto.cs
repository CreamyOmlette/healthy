using System;
using System.ComponentModel.DataAnnotations;

namespace HealthBuilder.Services.Dtos
{
    public class ScheduledRoutineDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public RoutineDto Routine { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}