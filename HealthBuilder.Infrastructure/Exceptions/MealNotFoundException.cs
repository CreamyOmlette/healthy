using System;

namespace HealthBuilder.Infrastructure.Exceptions
{
    public class MealNotFoundException : NotFoundException
    {
        public override string Message => "Meal not found";
    }
}