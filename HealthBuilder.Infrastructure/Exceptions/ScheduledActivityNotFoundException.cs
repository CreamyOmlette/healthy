using System;

namespace HealthBuilder.Infrastructure.Exceptions
{
    public class ScheduledActivityNotFoundException : NotFoundException
    {
        public override string Message => "Scheduled activity not found";
    }
}