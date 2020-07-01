namespace Leads.Domain.Clients.Exceptions
{
    using System;
    using Domain.Exceptions;


    public class ClientSourceExistsButDeletedException : DomainException
    {
        public ClientSourceExistsButDeletedException()
        {
        }

        public ClientSourceExistsButDeletedException(string message) : base(message)
        {
        }

        public ClientSourceExistsButDeletedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}