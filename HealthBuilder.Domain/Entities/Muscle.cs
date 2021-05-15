using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthBuilder.Core.Entities
{
    public class Muscle: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
    }
}
