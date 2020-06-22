namespace Leads.WebApi.Application.Areas.Api.Account.Requests.SignIn
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Queries.Criteria;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Authentication;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class SignInRequestHandler : IAsyncApiRequestHandler<SignInRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAuthenticationService<User> _authenticationService;


        public SignInRequestHandler(
            IAsyncQueryBuilder asyncQueryBuilder,
            IAuthenticationService<User> authenticationService)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }


        public async Task ExecuteAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(new FindByEmail(request.Email), cancellationToken);
            
            if (user == null || !user.Password.Check(request.Password))
                throw new ApiException(ErrorCodes.EmailOrPasswordIsIncorrect, "Wrong email and/or password");

            await _authenticationService.SignInAsync(user, cancellationToken);
        }
    }
}