namespace Infrastructure.Queries.Criteria.Common.Extensions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Abstractions;
    using Identification.Abstractions;


    public static class FindByIdExtensions
    {
        public static THasId FindById<THasId>(this IQueryBuilder queryBuilder, long id)
            where THasId : class, IHasId, new()
        {
            if (queryBuilder == null) throw new ArgumentNullException(nameof(queryBuilder));

            return queryBuilder
                .For<THasId>()
                .With(new FindById(id));
        }

        public static Task<THasId> FindByIdAsync<THasId>(
            this IAsyncQueryBuilder asyncQueryBuilder,
            long id,
            CancellationToken cancellationToken = default)
            where THasId : class, IHasId, new()
        {
            if (asyncQueryBuilder == null) throw new ArgumentNullException(nameof(asyncQueryBuilder));

            return asyncQueryBuilder
                .For<THasId>()
                .WithAsync(new FindById(id), cancellationToken);
        }
    }
}