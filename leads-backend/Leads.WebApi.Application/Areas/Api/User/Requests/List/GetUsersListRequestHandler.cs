namespace Leads.WebApi.Application.Areas.Api.User.Requests.List
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Users.Objects.Entities;
    using Dto;
    using Filters;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Pagination;
    using Infrastructure.Queries.Criteria;
    using Infrastructure.Requests.Handlers;


    public class GetUsersListRequestHandler : IAsyncApiRequestHandler<GetUsersListRequest, GetUsersListRequestResult>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;


        public GetUsersListRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<GetUsersListRequestResult> ExecuteAsync(
            GetUsersListRequest request,
            CancellationToken cancellationToken = default)
        {
            var entitiesList = await _queryBuilder
                .For<PaginatedList<User>>()
                .WithAsync(
                    new FindPaginatedByFilter<AdminUserFilter>(
                        request.Offset,
                        request.Count,
                        request.Filter),
                    cancellationToken);

            return new GetUsersListRequestResult(
                new PaginatedList<UserDto>(
                    _mapper.Map<List<UserDto>>(entitiesList.Items),
                    entitiesList.TotalCount));
        }
    }
}