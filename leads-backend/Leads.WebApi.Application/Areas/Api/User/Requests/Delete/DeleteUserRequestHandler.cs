namespace Leads.WebApi.Application.Areas.Api.User.Requests.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Objects.Entities;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class DeleteUserRequestHandler : IAsyncApiRequestHandler<DeleteUserRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;


        public DeleteUserRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
        }


        public async Task ExecuteAsync(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindNotDeletedByIdAsync<User>(request.Id, cancellationToken);
            
            if (user == null)
                throw new ApiException(ErrorCodes.UserNotFound, "User not found");
            
            user.Delete();
        }
    }
}