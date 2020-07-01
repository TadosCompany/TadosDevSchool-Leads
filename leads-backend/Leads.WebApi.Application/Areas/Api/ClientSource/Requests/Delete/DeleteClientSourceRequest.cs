namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Delete
{
    using Infrastructure.Requests;


    public class DeleteClientSourceRequest : IApiRequest
    {
        public long Id { get; set; }
    }
}