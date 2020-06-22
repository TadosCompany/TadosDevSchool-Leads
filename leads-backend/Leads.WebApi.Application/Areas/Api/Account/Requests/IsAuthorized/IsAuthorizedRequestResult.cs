namespace Leads.WebApi.Application.Areas.Api.Account.Requests.IsAuthorized
{
    using Infrastructure.Requests.Results;


    public class IsAuthorizedRequestResult : IApiRequestResult
    {
        public IsAuthorizedRequestResult(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }


        public bool IsAuthorized { get; }
    }
}