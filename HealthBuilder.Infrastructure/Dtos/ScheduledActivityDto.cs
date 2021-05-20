using System;

namespace HealthBuilder.Infrastructure.Dtos
{
    public class ScheduledActivityDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}