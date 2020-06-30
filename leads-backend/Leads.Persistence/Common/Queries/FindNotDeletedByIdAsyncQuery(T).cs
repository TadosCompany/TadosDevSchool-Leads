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


    public class FindNotDeletedByIdAsyncQuery<T> : LinqAsyncQueryBase<T, FindNotDeletedById, T>
        where T : class, IHasId, IDummyDeletable, new()
    {
        public FindNotDeletedByIdAsyncQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<T> AskAsync(FindNotDeletedById criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(
                x => x.Id == criterion.Id && x.DeletedAtUtc == null,
                cancellationToken);
        }
    }
}