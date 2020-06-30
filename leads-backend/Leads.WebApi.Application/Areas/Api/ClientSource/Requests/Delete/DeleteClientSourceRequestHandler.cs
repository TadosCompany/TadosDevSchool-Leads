namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Clients.Exceptions;
    using Domain.Clients.Objects;
    using Domain.Clients.Objects.Entities;
    using Domain.Common.Queries.Criteria.Extensions;
    using Dto;
    using Edit;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class DeleteClientSourceRequestHandler : IAsyncApiRequestHandler<DeleteClientSourceRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;


        public DeleteClientSourceRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
        }


        public async Task ExecuteAsync(DeleteClientSourceRequest request, CancellationToken cancellationToken = default)
        {
            var clientSource = await _queryBuilder
                .FindNotDeletedByIdAsync<ClientSource>(request.Id, cancellationToken);
                
            if (clientSource == null)
                throw new ApiException(ErrorCodes.ClientSourceNotFound, "ClientSource not found");
            
            clientSource.Delete();
        }
    }
}