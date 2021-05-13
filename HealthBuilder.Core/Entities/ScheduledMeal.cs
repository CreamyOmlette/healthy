namespace HealthBuilder.Core.Entities
{
    public class ScheduledMeal : ScheduledActivity
    {
        public Meal Meal { get; set; }
        public int MealId { get; set; }
    }
}