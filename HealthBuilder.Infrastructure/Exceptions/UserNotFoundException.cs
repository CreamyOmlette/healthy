
namespace HealthBuilder.Infrastructure.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public override string Message => "User not found";
    }
}