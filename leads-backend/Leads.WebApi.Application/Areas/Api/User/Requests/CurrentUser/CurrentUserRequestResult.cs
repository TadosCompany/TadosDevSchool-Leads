namespace Leads.WebApi.Application.Areas.Api.User.Requests.CurrentUser
{
    using Dto;
    using Infrastructure.Requests.Results;


    public class CurrentUserRequestResult : IApiRequestResult
    {
        public CurrentUserRequestResult(UserDto user)
        {
            User = user;
        }


        public UserDto User { get; }
    }
}