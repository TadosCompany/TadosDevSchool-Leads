namespace Leads.WebApi.Application.Areas.Api.User.Requests.Add
{
    using Dto;
    using Infrastructure.Requests.Results;


    public class AddUserRequestResult : IApiRequestResult
    {
        public AddUserRequestResult(UserDto user)
        {
            User = user;
        }


        public UserDto User { get; }
    }
}