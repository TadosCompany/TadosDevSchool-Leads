namespace Leads.WebApi.Application.Areas.Api.User.Requests.ChangePassword
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Exceptions;
    using Domain.Users.Objects.Entities;
    using Infrastructure.Authorization.Providers;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class ChangePasswordRequestHandler : IApiRequestHandler<ChangePasswordRequest>
    {
        private readonly IUserProvider<User> _userProvider;


        public ChangePasswordRequestHandler(IUserProvider<User> userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }


        public void Execute(ChangePasswordRequest request)
        {
            try
            {
                if (!_userProvider.User.Password.Check(request.OldPassword))
                    throw new ApiException(ErrorCodes.EmailOrPasswordIsIncorrect, "Old password is invalid");
                
                _userProvider.User.SetPassword(request.NewPassword);
            }
            catch (PasswordIsTooWeakException)
            {
                throw new ApiException(ErrorCodes.PasswordIsTooWeak, "Password is too weak");
            }
        }
    }
}