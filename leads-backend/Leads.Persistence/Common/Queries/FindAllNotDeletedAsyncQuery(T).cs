namespace Leads.Persistence.Common.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Common.Queries.Criteria;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindAllNotDeletedAsyncQuery<T> : LinqAsyncQueryBase<T, FindAllNotDeleted, List<T>>
        where T : class, IHasId, IDummyDeletable, new()
    {
        public FindAllNotDeletedAsyncQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<List<T>> AskAsync(FindAllNotDeleted criterion,
            CancellationToken cancellationToken = default)
        {
            var query = Query.Where(x => x.DeletedAtUtc == null);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}