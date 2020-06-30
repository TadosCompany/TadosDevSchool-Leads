namespace Leads.WebApi.Application.Areas.Api.User.Requests.Edit
{
    using Dto;
    using Infrastructure.Requests.Results;


    public class EditUserRequestResult : IApiRequestResult
    {
        public EditUserRequestResult(UserDto user)
        {
            User = user;
        }


        public UserDto User { get; }
    }
}