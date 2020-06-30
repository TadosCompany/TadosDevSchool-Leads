namespace Leads.WebApi.Application.Areas.Api.User.Requests.ResetPassword
{
    using Infrastructure.Requests;


    public class ResetPasswordRequest : IApiRequest
    {
        // for admin action we can use Id
        
        public long Id { get; set; }
    }
}