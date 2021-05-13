namespace HealthBuilder.Core.Entities
{
    public class ScheduledRoutine : ScheduledActivity
    {
        public Routine Routine { get; set; }
        public int RoutineId { get; set; }
    }
}