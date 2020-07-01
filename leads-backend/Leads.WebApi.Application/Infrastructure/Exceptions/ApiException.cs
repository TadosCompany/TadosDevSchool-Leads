namespace Leads.WebApi.Application.Infrastructure.Exceptions
{
    using System;


    public class ApiException : Exception
    {
        public ApiException(ErrorCodes code, string message) : base(message)
        {
            Code = code;
        }

        public ApiException(ErrorCodes code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }


        public ErrorCodes Code { get; }
    }
}