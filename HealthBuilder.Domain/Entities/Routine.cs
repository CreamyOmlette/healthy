using System.Collections.Generic;
using System;
namespace HealthBuilder.Core.Entities
{
    public class Routine: BaseEntity
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
        
        public virtual List<ScheduledRoutine> Routines { get; set; }
    }
}