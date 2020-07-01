namespace Leads.WebApi.Test.Tests.Common.Api
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Areas.Api.User.Requests.CurrentUser;


    public class UserApi : ApiBase
    {
        public UserApi(HttpClient client) : base(client)
        {
        }


        public Task<ApiResult<CurrentUserRequestResult>> CurrentUserAsync()
        {
            return MakeRequestAsync<CurrentUserRequest, CurrentUserRequestResult>(
                "api/user/current",
                new CurrentUserRequest());
        }
    }
}