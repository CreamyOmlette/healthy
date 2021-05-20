using System;

namespace HealthBuilder.Infrastructure.Exceptions
{
    public class EmptySpecificationException : ArgumentException
    {
        public override string Message => "Specification is empty";
    }
}