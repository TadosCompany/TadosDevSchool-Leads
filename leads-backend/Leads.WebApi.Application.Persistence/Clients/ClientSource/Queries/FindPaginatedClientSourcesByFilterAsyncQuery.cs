namespace Leads.WebApi.Application.Persistence.Clients.ClientSource.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Api.ClientSource.Filters;
    using Domain.Clients.Objects.Entities;
    using global::Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using global::Infrastructure.Linq.Providers.Abstractions;
    using global::Infrastructure.Queries.Linq.Base;
    using Infrastructure.Pagination;
    using Infrastructure.Queries.Criteria;


    public class FindPaginatedClientSourcesByFilterAsyncQuery
        : LinqAsyncQueryBase<ClientSource, FindPaginatedByFilter<AdminClientSourceFilter>, PaginatedList<ClientSource>>
    {
        public FindPaginatedClientSourcesByFilterAsyncQuery(
            ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override async Task<PaginatedList<ClientSource>> AskAsync(
            FindPaginatedByFilter<AdminClientSourceFilter> criterion,
            CancellationToken cancellationToken = default)
        {
            var query = Query;

            if (criterion.Filter != null)
            {
                if (!criterion.Filter.ShowDeleted)
                {
                    query = query.Where(x => x.DeletedAtUtc == null);
                }
                
                if (!string.IsNullOrWhiteSpace(criterion.Filter.SearchString))
                {
                    query = query.Where(x => x.Name.Contains(criterion.Filter.SearchString));
                }
            }

            var totalCount = await ToAsync(query).CountAsync(cancellationToken);
            
            return new PaginatedList<ClientSource>(
                await ToAsync(
                    query
                        .OrderBy(x => x.Name)
                        .Skip(criterion.Offset)
                        .Take(criterion.Count)
                ).ToListAsync(cancellationToken),
                totalCount);
        }
    }
}