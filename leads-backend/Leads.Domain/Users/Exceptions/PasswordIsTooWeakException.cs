namespace Leads.Domain.Users.Exceptions
{
    using Domain.Exceptions;


    public class PasswordIsTooWeakException : DomainException
    {
        public PasswordIsTooWeakException()
        {
        }

        public PasswordIsTooWeakException(string message) : base(message)
        {
        }
    }
}