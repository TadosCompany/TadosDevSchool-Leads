namespace Leads.WebApi.Application.Infrastructure.Exceptions.Attributes
{
    using System;


    [AttributeUsage(AttributeTargets.Field)]
    public class DefaultMessageAttribute : Attribute
    {
        public DefaultMessageAttribute(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(message));

            Message = message;
        }


        public string Message { get; }
    }
}