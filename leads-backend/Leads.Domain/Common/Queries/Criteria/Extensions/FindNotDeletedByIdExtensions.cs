namespace Leads.Domain.Common.Queries.Criteria.Extensions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Builders.Abstractions;


    public static class FindNotDeletedByIdExtensions
    {
        public static T FindNotDeletedById<T>(this IQueryBuilder queryBuilder, long id)
            where T : class, IHasId, IDummyDeletable, new()
        {
            return queryBuilder.For<T>().With(new FindNotDeletedById(id));
        }

        public static Task<T> FindNotDeletedByIdAsync<T>(
            this IAsyncQueryBuilder asyncQueryBuilder,
            long id,
            CancellationToken cancellationToken = default)
            where T : class, IHasId, IDummyDeletable, new()
        {
            return asyncQueryBuilder
                .For<T>()
                .WithAsync(new FindNotDeletedById(id), cancellationToken);
        }
    }
}