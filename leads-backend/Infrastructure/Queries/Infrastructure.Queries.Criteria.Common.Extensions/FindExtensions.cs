namespace Infrastructure.Queries.Criteria.Common.Extensions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Abstractions;


    public static class FindExtensions
    {
        public static TResult Find<TResult>(this IQueryBuilder queryBuilder)
        {
            if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));

            return queryBuilder
                .For<TResult>()
                .With(new EmptyCriterion());
        }

        public static Task<TResult> FindAsync<TResult>(
            this IAsyncQueryBuilder asyncQueryBuilder,
            CancellationToken cancellationToken = default)
        {
            if (asyncQueryBuilder == null) throw new ArgumentNullException(nameof(asyncQueryBuilder));

            return asyncQueryBuilder
                .For<TResult>()
                .WithAsync(new EmptyCriterion(), cancellationToken);
        }
    }
}