using System;
using System.Collections.Generic;

namespace HealthBuilder.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DoB { get; set; }

        public virtual List<ScheduledActivity> ScheduledActivities { get; set; }
    }
}