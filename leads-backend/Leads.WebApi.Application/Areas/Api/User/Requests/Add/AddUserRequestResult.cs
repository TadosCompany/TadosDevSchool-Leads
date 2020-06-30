namespace Leads.WebApi.Application.Areas.Api.User.Requests.Add
{
    using Dto;
    using Infrastructure.Requests.Results;

    public class AddUserRequestResult : IApiRequestResult
    {
        public AddUserRequestResult(UserDto userDto)
        {
            UserDto = userDto;
        }
        

        public UserDto UserDto { get; }
    }
}