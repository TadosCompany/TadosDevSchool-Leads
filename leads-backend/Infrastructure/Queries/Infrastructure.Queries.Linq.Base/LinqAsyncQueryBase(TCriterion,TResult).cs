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


    public abstract class LinqAsyncQueryBase<TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;
        private readonly IAsyncQueryableFactory _asyncQueryableFactory;


        protected LinqAsyncQueryBase(ILinqProvider linqProvider, IAsyncQueryableFactory asyncQueryableFactory)
        {
            _linqProvider = linqProvider ?? throw new ArgumentNullException(nameof(linqProvider));
            _asyncQueryableFactory =
                asyncQueryableFactory ?? throw new ArgumentNullException(nameof(asyncQueryableFactory));
        }


        protected virtual IQueryable<THasId> Query<THasId>()
            where THasId : class, IHasId, new()
            => _linqProvider.Query<THasId>();

        protected virtual IAsyncQueryable<THasId> AsyncQuery<THasId>()
            where THasId : class, IHasId, new()
            => ToAsync(Query<THasId>());
        
        protected IAsyncQueryable<THasId> ToAsync<THasId>(IQueryable<THasId> query)
            where THasId : class, IHasId, new()
            => _asyncQueryableFactory.CreateFrom(query);


        public abstract Task<TResult> AskAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}