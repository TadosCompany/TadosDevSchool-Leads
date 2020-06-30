namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Clients.Exceptions;
    using Domain.Clients.Objects;
    using Domain.Clients.Objects.Entities;
    using Domain.Clients.Services.ClientSource.Abstractions;
    using Domain.Common.Queries.Criteria.Extensions;
    using Dto;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions;
    using Infrastructure.Requests.Handlers;


    public class EditClientSourceRequestHandler
        : IAsyncApiRequestHandler<EditClientSourceRequest, EditClientSourceRequestResult>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IClientSourceService _clientSourceService;
        private readonly IMapper _mapper;


        public EditClientSourceRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IClientSourceService clientSourceService,
            IMapper mapper)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _clientSourceService = clientSourceService ?? throw new ArgumentNullException(nameof(clientSourceService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<EditClientSourceRequestResult> ExecuteAsync(
            EditClientSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var clientSource = await _queryBuilder
                    .FindNotDeletedByIdAsync<ClientSource>(request.Id, cancellationToken);
                
                if (clientSource == null)
                    throw new ApiException(ErrorCodes.ClientSourceNotFound, "ClientSource not found");

                await _clientSourceService.EditAsync(clientSource, request.Name, cancellationToken);
                
                return new EditClientSourceRequestResult(_mapper.Map<ClientSourceDto>(clientSource));
            }
            catch (ClientSourceAlreadyExistsException)
            {
                throw new ApiException(ErrorCodes.ClientSourceAlreadyExists, "Client source already exists");
            }
        }
    }
}