namespace Leads.WebApi.Application.Areas.Api.User.Requests.ResetPassword
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;
    using Infrastructure.Security.Passwords;


    public class ResetPasswordRequestHandler : IAsyncApiRequestHandler<ResetPasswordRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IUserService _userService;
        private readonly IApiExceptionFactory _apiExceptionFactory;



        public ResetPasswordRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IPasswordGenerator passwordGenerator,
            IUserService userService,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _passwordGenerator = passwordGenerator ?? throw new ArgumentNullException(nameof(passwordGenerator));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(
            ResetPasswordRequest request,
            CancellationToken cancellationToken = default)
        {
            User user = await _queryBuilder.FindNotDeletedByIdAsync<User>(request.Id, cancellationToken);

            if (user == null)
                throw _apiExceptionFactory.Create(ErrorCodes.UserNotFound);

            string password = _passwordGenerator.Generate();

            await _userService.ResetPasswordAsync(user, password, cancellationToken);
        }
    }
}