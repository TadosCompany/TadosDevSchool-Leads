namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Restore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Clients.Exceptions;
    using Domain.Clients.Objects;
    using Domain.Clients.Objects.Entities;
    using Domain.Clients.Services.ClientSource.Abstractions;
    using Domain.Common.Queries.Criteria.Extensions;
    using Dto;
    using Edit;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class RestoreClientSourceRequestHandler : IAsyncApiRequestHandler<RestoreClientSourceRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IClientSourceService _clientSourceService;


        public RestoreClientSourceRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IClientSourceService clientSourceService)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _clientSourceService = clientSourceService ?? throw new ArgumentNullException(nameof(clientSourceService));
        }


        public async Task ExecuteAsync(
            RestoreClientSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var clientSource = await _queryBuilder
                    .FindNotDeletedByIdAsync<ClientSource>(request.Id, cancellationToken);
                
                if (clientSource == null)
                    throw new ApiException(ErrorCodes.ClientSourceNotFound, "ClientSource not found");

                await _clientSourceService.RestoreAsync(clientSource, cancellationToken);
            }
            catch (ClientSourceAlreadyExistsException)
            {
                throw new ApiException(ErrorCodes.ClientSourceAlreadyExists, "Client source already exists");
            }
        }
    }
}