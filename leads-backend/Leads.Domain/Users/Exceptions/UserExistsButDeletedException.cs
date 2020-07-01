namespace Leads.Domain.Users.Exceptions
{
    using System;
    using Domain.Exceptions;


    public class UserExistsButDeletedException : DomainException
    {
        public UserExistsButDeletedException()
        {
        }

        public UserExistsButDeletedException(string message) : base(message)
        {
        }

        public UserExistsButDeletedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}