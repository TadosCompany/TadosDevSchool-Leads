namespace Leads.WebApi.Application.Areas.Api.User.Requests.Restore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Exceptions;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using global::Infrastructure.Queries.Criteria.Common.Extensions;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class RestoreUserRequestHandler : IAsyncApiRequestHandler<RestoreUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IUserService _userService;


        public RestoreUserRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IUserService userService)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        public async Task ExecuteAsync(RestoreUserRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _queryBuilder.FindByIdAsync<User>(request.Id, cancellationToken);
            
                if (user == null)
                    throw new ApiException(ErrorCodes.UserNotFound, "User not found");

                await _userService.RestoreAsync(user, cancellationToken);
            }
            catch (UserAlreadyExistsException)
            {
                throw new ApiException(ErrorCodes.UserAlreadyExists, "User with email already exists");
            }
        }
    }
}