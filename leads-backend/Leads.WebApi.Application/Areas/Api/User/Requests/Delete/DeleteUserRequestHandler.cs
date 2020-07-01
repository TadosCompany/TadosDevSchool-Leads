namespace Leads.WebApi.Application.Areas.Api.User.Requests.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Objects.Entities;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class DeleteUserRequestHandler : IAsyncApiRequestHandler<DeleteUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public DeleteUserRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindNotDeletedByIdAsync<User>(request.Id, cancellationToken);

            if (user == null)
                throw _apiExceptionFactory.Create(ErrorCodes.UserNotFound);

            user.Delete();
        }
    }
}