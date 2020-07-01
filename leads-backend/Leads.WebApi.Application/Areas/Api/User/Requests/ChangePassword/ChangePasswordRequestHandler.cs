namespace Leads.WebApi.Application.Areas.Api.User.Requests.ChangePassword
{
    using System;
    using Domain.Users.Objects.Entities;
    using Infrastructure.Authorization.Providers;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class ChangePasswordRequestHandler : IApiRequestHandler<ChangePasswordRequest>
    {
        private readonly IUserProvider<User> _userProvider;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public ChangePasswordRequestHandler(
            IUserProvider<User> userProvider,
            IApiExceptionFactory apiExceptionFactory)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public void Execute(ChangePasswordRequest request)
        {
            if (!_userProvider.User.Password.Check(request.OldPassword))
                throw _apiExceptionFactory.Create(ErrorCodes.EmailOrPasswordIsIncorrect);

            _userProvider.User.SetPassword(request.NewPassword);
        }
    }
}