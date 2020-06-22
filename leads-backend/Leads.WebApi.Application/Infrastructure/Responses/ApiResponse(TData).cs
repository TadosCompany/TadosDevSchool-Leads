namespace Leads.WebApi.Application.Infrastructure.Responses
{
    using System;


    public class ApiResponse<TData> : ApiResponse
    {
        public ApiResponse(TData data)
        {
            Data = data;
        }

        public ApiResponse(Exception exception) : base(exception)
        {
        }


        public TData Data { get; }
    }
}