namespace Infrastructure.Queries.Linq.Base
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Criteria.Abstractions;
    using Identification.Abstractions;
    using Infrastructure.Linq.AsyncQueryable.Abstractions;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;


    public abstract class LinqAsyncQueryBase<THasId, TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where THasId : class, IHasId, new()
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;
        private readonly IAsyncQueryableFactory _asyncQueryableFactory;

        protected LinqAsyncQueryBase(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory)
        {
            _linqProvider = linqProvider ?? throw new ArgumentNullException(nameof(linqProvider));
            _asyncQueryableFactory =
                asyncQueryableFactory ?? throw new ArgumentNullException(nameof(asyncQueryableFactory));
        }


        protected virtual IQueryable<THasId> Query => _linqProvider.Query<THasId>();
        
        protected virtual IAsyncQueryable<THasId> AsyncQuery => ToAsync(Query);

        protected IAsyncQueryable<TOtherHasId> ToAsync<TOtherHasId>(IQueryable<TOtherHasId> query)
            where TOtherHasId : THasId
            => _asyncQueryableFactory.CreateFrom(query); 


        public abstract Task<TResult> AskAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}