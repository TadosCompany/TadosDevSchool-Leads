namespace Leads.WebApi.Application.Areas.Api.Account.Requests.SignIn
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Queries.Criteria;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Authentication;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class SignInRequestHandler : IAsyncApiRequestHandler<SignInRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAuthenticationService<User> _authenticationService;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public SignInRequestHandler(
            IAsyncQueryBuilder asyncQueryBuilder,
            IAuthenticationService<User> authenticationService,
            IApiExceptionFactory apiExceptionFactory)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(new FindNotDeletedByEmail(request.Email), cancellationToken);

            if (user == null || !user.Password.Check(request.Password))
                throw _apiExceptionFactory.Create(ErrorCodes.EmailOrPasswordIsIncorrect);

            await _authenticationService.SignInAsync(user, cancellationToken);
        }
    }
}