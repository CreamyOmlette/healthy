using System.Collections.Generic;

namespace HealthBuilder.Core.Entities
{
    public class Exercise: BaseEntity
    {
        public string Name { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int Intensity { get; set; }
        public int? Time { get; set; }
        
        public virtual List<Routine> Routines { get; set; }
        public virtual List<Muscle> Muscles { get; set; }
        public string Description { get; set; }
    }
}