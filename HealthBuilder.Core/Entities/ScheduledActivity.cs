using System;

namespace HealthBuilder.Core.Entities
{
    public abstract class ScheduledActivity : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
    
}