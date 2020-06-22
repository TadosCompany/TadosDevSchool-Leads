namespace Leads.WebApi.Application.Areas.Api.Account.Requests.IsAuthorized
{
    using System;
    using Domain.Users.Objects.Entities;
    using Infrastructure.Authorization.Providers;
    using Infrastructure.Requests.Handlers;


    public class IsAuthorizedRequestHandler : IApiRequestHandler<IsAuthorizedRequest, IsAuthorizedRequestResult>
    {
        private readonly IUserProvider<User> _userProvider;


        public IsAuthorizedRequestHandler(IUserProvider<User> userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }


        public IsAuthorizedRequestResult Execute(IsAuthorizedRequest request)
        {
            return new IsAuthorizedRequestResult(_userProvider.User != null);
        }
    }
}