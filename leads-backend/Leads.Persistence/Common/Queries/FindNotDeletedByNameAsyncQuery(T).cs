namespace Leads.Persistence.Common.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Common.Queries.Criteria;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindNotDeletedByNameAsyncQuery<T> : LinqAsyncQueryBase<T, FindNotDeletedByName, T>
        where T : class, IHasId, IDummyDeletable, IHasName, new()
    {
        public FindNotDeletedByNameAsyncQuery(ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
            : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<T> AskAsync(
            FindNotDeletedByName criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(x => x.DeletedAtUtc == null && x.Name == criterion.Name, cancellationToken);
        }
    }
}