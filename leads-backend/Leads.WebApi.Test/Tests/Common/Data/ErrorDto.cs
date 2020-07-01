namespace Leads.WebApi.Test.Tests.Common.Data
{
    using Application;

    public class ErrorDto
    {
        public ErrorCodes Code { get; set; }

        public string Message { get; set; }
    }
}