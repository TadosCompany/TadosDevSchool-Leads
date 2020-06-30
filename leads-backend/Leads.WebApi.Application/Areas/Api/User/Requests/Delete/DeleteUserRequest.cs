namespace Leads.WebApi.Application.Areas.Api.User.Requests.Delete
{
    using Infrastructure.Requests;


    public class DeleteUserRequest : IApiRequest
    {
        public long Id { get; set; }
    }
}