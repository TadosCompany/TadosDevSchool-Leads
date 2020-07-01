namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Clients.Objects.Entities;
    using Domain.Clients.Services.ClientSource.Abstractions;
    using Dto;
    using Infrastructure.Requests.Handlers;


    public class AddClientSourceRequestHandler
        : IAsyncApiRequestHandler<AddClientSourceRequest, AddClientSourceRequestResult>
    {
        private readonly IClientSourceService _clientSourceService;
        private readonly IMapper _mapper;


        public AddClientSourceRequestHandler(
            IClientSourceService clientSourceService,
            IMapper mapper)
        {
            _clientSourceService = clientSourceService ?? throw new ArgumentNullException(nameof(clientSourceService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<AddClientSourceRequestResult> ExecuteAsync(
            AddClientSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            var clientSource = new ClientSource(request.Name);

            await _clientSourceService.CreateAsync(clientSource, cancellationToken);

            return new AddClientSourceRequestResult(_mapper.Map<ClientSourceDto>(clientSource));
        }
    }
}