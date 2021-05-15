using System.Collections.Generic;

namespace HealthBuilder.Core.Entities
{
    public class Meal: BaseEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Proteins { get; set; }
        public string Description { get; set; }
        public int Mass { get; set; }
        public string ImgSrc { get; set; }

        public List<ScheduledMeal> ScheduledMeals { get; set; }
    }
}