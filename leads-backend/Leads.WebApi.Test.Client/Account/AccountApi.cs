namespace Leads.WebApi.Test.Client.Account
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Common.Results;
    using Requests;
    using Results;

    public class AccountApi : ApiClientBase
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
                new SignInRequest(email, password));
        }

        public Task<ApiResult> SignOutAsync()
        {
            return MakeRequestAsync("api/account/signOut", new SignOutRequest());
        }
    }
}