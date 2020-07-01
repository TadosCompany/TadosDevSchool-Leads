namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Restore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Clients.Objects.Entities;
    using Domain.Clients.Services.ClientSource.Abstractions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using global::Infrastructure.Queries.Criteria.Common.Extensions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class RestoreClientSourceRequestHandler : IAsyncApiRequestHandler<RestoreClientSourceRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IClientSourceService _clientSourceService;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public RestoreClientSourceRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IClientSourceService clientSourceService,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _clientSourceService = clientSourceService ?? throw new ArgumentNullException(nameof(clientSourceService));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(
            RestoreClientSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            var clientSource = await _queryBuilder
                .FindByIdAsync<ClientSource>(request.Id, cancellationToken);

            if (clientSource == null)
                throw _apiExceptionFactory.Create(ErrorCodes.ClientSourceNotFound);

            await _clientSourceService.RestoreAsync(clientSource, cancellationToken);
        }
    }
}