namespace Leads.WebApi.Application.Areas.Api.Account.Requests.SignOut
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Infrastructure.Authentication;
    using Infrastructure.Requests.Handlers;


    public class SignOutRequestHandler : IAsyncApiRequestHandler<SignOutRequest>
    {
        private readonly IAuthenticationService<User> _authenticationService;


        public SignOutRequestHandler(IAuthenticationService<User> authenticationService)
        {
            _authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }


        public Task ExecuteAsync(SignOutRequest request, CancellationToken cancellationToken = default)
        {
            return _authenticationService.SignOutAsync(cancellationToken);
        }
    }
}