namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Clients.Objects.Entities;
    using Domain.Common.Queries.Criteria.Extensions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class DeleteClientSourceRequestHandler : IAsyncApiRequestHandler<DeleteClientSourceRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public DeleteClientSourceRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(DeleteClientSourceRequest request, CancellationToken cancellationToken = default)
        {
            var clientSource = await _queryBuilder
                .FindNotDeletedByIdAsync<ClientSource>(request.Id, cancellationToken);

            if (clientSource == null)
                throw _apiExceptionFactory.Create(ErrorCodes.ClientSourceNotFound);
            
            clientSource.Delete();
        }
    }
}