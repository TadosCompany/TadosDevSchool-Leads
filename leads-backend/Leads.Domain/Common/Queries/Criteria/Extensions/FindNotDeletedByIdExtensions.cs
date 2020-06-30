namespace Leads.Domain.Common.Queries.Criteria.Extensions
{
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Builders.Abstractions;


    public static class FindNotDeletedByIdExtensions
    {
        public static T FindNotDeletedById<T>(this IQueryBuilder queryBuilder, long id)
            where T : class, IHasId, IDummyDeletable, new()
        {
            return queryBuilder.For<T>().With(new FindNotDeletedById(id));
        }
    }
}