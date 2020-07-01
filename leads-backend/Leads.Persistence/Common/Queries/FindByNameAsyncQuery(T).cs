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


    public class FindByNameAsyncQuery<T> : LinqAsyncQueryBase<T, FindByName, T>
        where T : class, IHasId, IHasName, new()
    {
        public FindByNameAsyncQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<T> AskAsync(FindByName criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(
                x => x.Name == criterion.Name,
                cancellationToken);
        }
    }
}