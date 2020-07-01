namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Restore
{
    using Infrastructure.Requests;


    public class RestoreClientSourceRequest : IApiRequest
    {
        public long Id { get; set; }
    }
}