namespace Leads.WebApi.Test.Tests.Common.Api
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Areas.Api.Account.Requests.IsAuthorized;
    using Application.Areas.Api.Account.Requests.SignIn;
    using Application.Areas.Api.Account.Requests.SignOut;


    public class AccountApi : ApiBase
    {
        public AccountApi(HttpClient client) : base(client)
        {
        }


        public Task<ApiResult<IsAuthorizedRequestResult>> IsAuthorizedAsync()
        {
            return MakeRequestAsync<IsAuthorizedRequest, IsAuthorizedRequestResult>(
                "api/account/isAuthorized",
                new IsAuthorizedRequest());
        }

        public Task<ApiResult> SignInAsync(string email, string password)
        {
            return MakeRequestAsync(
                "api/account/signIn",
                new SignInRequest()
                {
                    Email = email,
                    Password = password,
                });
        }

        public Task<ApiResult> SignOutAsync()
        {
            return MakeRequestAsync("api/account/signOut", new SignOutRequest());
        }
    }
}