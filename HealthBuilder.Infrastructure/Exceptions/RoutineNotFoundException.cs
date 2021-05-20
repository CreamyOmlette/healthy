using System;

namespace HealthBuilder.Infrastructure.Exceptions
{
    public class RoutineNotFoundException : NotFoundException
    {
        public override string Message => "Routine not found";
    }
}