namespace Leads.WebApi.Application.Areas.Api.User.Requests.Restore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using global::Infrastructure.Queries.Criteria.Common.Extensions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class RestoreUserRequestHandler : IAsyncApiRequestHandler<RestoreUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IUserService _userService;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public RestoreUserRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IUserService userService,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(RestoreUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindByIdAsync<User>(request.Id, cancellationToken);

            if (user == null)
                throw _apiExceptionFactory.Create(ErrorCodes.UserNotFound);

            await _userService.RestoreAsync(user, cancellationToken);
        }
    }
}