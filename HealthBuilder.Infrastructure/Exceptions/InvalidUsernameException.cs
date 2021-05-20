using System;

namespace HealthBuilder.Infrastructure.Exceptions
{
    public class InvalidUsernameException : ArgumentException
    {
        public override string Message => "Username not valid";
    }
}