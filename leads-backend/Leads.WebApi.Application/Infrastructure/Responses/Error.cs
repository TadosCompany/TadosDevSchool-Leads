namespace Leads.WebApi.Application.Infrastructure.Responses
{
    using System;
    using Exceptions;


    public class Error
    {
        [Obsolete("Only for reflection", true)]
        public Error()
        {
        }

        public Error(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            Message = exception.Message;

            if (exception is ApiException apiException)
            {
                Code = apiException.Code;
            }
        }


        public string Message { get; }

        public ErrorCodes Code { get; }
    }
}