namespace Leads.WebApi.Application.Infrastructure.Exceptions
{
    using System;


    public class ApiException : Exception
    {
        public ApiException(long code, string message) : base(message)
        {
            Code = code;
        }

        public ApiException(long code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }


        public long Code { get; }
    }
}