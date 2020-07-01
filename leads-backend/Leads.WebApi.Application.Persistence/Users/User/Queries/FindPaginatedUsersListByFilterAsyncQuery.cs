namespace Leads.WebApi.Application.Persistence.Users.User.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Api.User.Filters;
    using Domain.Users.Objects.Entities;
    using global::Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using global::Infrastructure.Linq.Providers.Abstractions;
    using global::Infrastructure.Queries.Linq.Base;
    using Infrastructure.Pagination;
    using Infrastructure.Queries.Criteria;


    public class FindPaginatedUsersListByFilterAsyncQuery
        : LinqAsyncQueryBase<User, FindPaginatedByFilter<AdminUserFilter>, PaginatedList<User>>
    {
        public FindPaginatedUsersListByFilterAsyncQuery(ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override async Task<PaginatedList<User>> AskAsync(
            FindPaginatedByFilter<AdminUserFilter> criterion,
            CancellationToken cancellationToken = default)
        {
            var query = Query;
            
            if (criterion.Filter != null)
            {
                if (!criterion.Filter.ShowDeleted)
                {
                    query = query.Where(x => x.DeletedAtUtc == null);
                }
                
                if (criterion.Filter.Roles != null && criterion.Filter.Roles.Length > 0)
                {
                    query = query.Where(x => criterion.Filter.Roles.Contains(x.Role));
                }

                if (!string.IsNullOrWhiteSpace(criterion.Filter.SearchString))
                {
                    query = query.Where(x => x.Email.Contains(criterion.Filter.SearchString));
                }
            }

            var totalCount = await ToAsync(query).CountAsync(cancellationToken);
            
            return new PaginatedList<User>(
                await ToAsync(
                    query
                        .OrderBy(x => x.Email)
                        .Skip(criterion.Offset)
                        .Take(criterion.Count)
                    ).ToListAsync(cancellationToken),
                totalCount);
        }
    }
}