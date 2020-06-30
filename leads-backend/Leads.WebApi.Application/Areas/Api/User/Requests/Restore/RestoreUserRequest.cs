namespace Leads.WebApi.Application.Areas.Api.User.Requests.Restore
{
    using Infrastructure.Requests;


    public class RestoreUserRequest : IApiRequest
    {
        public long Id { get; set; }
    }
}