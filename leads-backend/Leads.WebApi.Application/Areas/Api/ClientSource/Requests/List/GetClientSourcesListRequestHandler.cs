namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.List
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Clients.Objects.Entities;
    using Dto;
    using Filters;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Pagination;
    using Infrastructure.Queries.Criteria;
    using Infrastructure.Requests.Handlers;


    public class GetClientSourcesListRequestHandler : IAsyncApiRequestHandler<GetClientSourcesListRequest,
        GetClientSourcesListRequestResult>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;


        public GetClientSourcesListRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IMapper mapper)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<GetClientSourcesListRequestResult> ExecuteAsync(
            GetClientSourcesListRequest request,
            CancellationToken cancellationToken = default)
        {
            var entitiesList = await _queryBuilder
                .For<PaginatedList<ClientSource>>()
                .WithAsync(new FindPaginatedByFilter<AdminClientSourceFilter>(
                    request.Offset,
                    request.Count,
                    request.Filter), cancellationToken);

            return new GetClientSourcesListRequestResult(
                new PaginatedList<ClientSourceDto>(
                    _mapper.Map<List<ClientSourceDto>>(entitiesList.Items),
                    entitiesList.TotalCount));
        }
    }
}