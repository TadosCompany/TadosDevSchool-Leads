namespace Infrastructure.Queries.Builders.Default
{
    using System;
    using Abstractions;
    using Criteria.Abstractions;
    using Factories.Abstractions;


    public class QueryFor<TResult> : IQueryFor<TResult>
    {
        private readonly IQueryFactory _queryFactory;


        public QueryFor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        }


        public TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            return _queryFactory
                .Create<TCriterion, TResult>()
                .Ask(criterion);
        }
    }
}