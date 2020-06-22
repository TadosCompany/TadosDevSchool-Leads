namespace Leads.WebApi.Application.Infrastructure.Responses
{
    using System;


    public class ApiResponse
    {
        public ApiResponse()
        {
            Success = true;
            Error = null;
        }

        public ApiResponse(Exception exception)
        {
            Success = false;
            Error = new Error(exception);
        }


        public bool Success { get; }

        public Error Error { get; }
    }
}