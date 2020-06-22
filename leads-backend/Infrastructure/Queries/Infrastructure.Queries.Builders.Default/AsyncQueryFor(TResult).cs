namespace Infrastructure.Queries.Builders.Default
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Criteria.Abstractions;
    using Factories.Abstractions;


    public class AsyncQueryFor<TResult> : IAsyncQueryFor<TResult>
    {
        private readonly IAsyncQueryFactory _asyncQueryFactory;


        public AsyncQueryFor(IAsyncQueryFactory asyncQueryFactory)
        {
            _asyncQueryFactory = asyncQueryFactory ?? throw new ArgumentNullException(nameof(asyncQueryFactory));
        }


        public Task<TResult> WithAsync<TCriterion>(
            TCriterion criterion,
            CancellationToken cancellationToken = default) where TCriterion : ICriterion
        {
            return _asyncQueryFactory
                .Create<TCriterion, TResult>()
                .AskAsync(criterion, cancellationToken);
        }
    }
}