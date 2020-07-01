namespace Leads.Domain.Clients.Exceptions
{
    using System;
    using Domain.Exceptions;


    public class ClientSourceAlreadyExistsException : DomainException
    {
        public ClientSourceAlreadyExistsException()
        {
        }

        public ClientSourceAlreadyExistsException(string message) : base(message)
        {
        }

        public ClientSourceAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}