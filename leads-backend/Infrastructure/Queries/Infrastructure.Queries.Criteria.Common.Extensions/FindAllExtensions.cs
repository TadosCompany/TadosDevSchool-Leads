namespace Infrastructure.Queries.Criteria.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Abstractions;


    public static class FindAllExtensions
    {
        public static List<TResult> FindAll<TResult>(this IQueryBuilder queryBuilder)
        {
            if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));

            return queryBuilder
                .For<List<TResult>>()
                .With(new FindAll());
        }

        public static Task<List<TResult>> FindAllAsync<TResult>(
            this IAsyncQueryBuilder asyncQueryBuilder,
            CancellationToken cancellationToken = default)
        {
            if (asyncQueryBuilder == null) throw new ArgumentNullException(nameof(asyncQueryBuilder));

            return asyncQueryBuilder
                .For<List<TResult>>()
                .WithAsync(new FindAll(), cancellationToken);
        }
    }
}