namespace Leads.Domain.Users.Exceptions
{
    using Domain.Exceptions;


    public class UserAlreadyExistsException : DomainException
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }
}