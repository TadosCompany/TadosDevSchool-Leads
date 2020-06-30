namespace Leads.Domain.Common.Queries.Criteria.Extensions
{
    using System.Collections.Generic;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Builders.Abstractions;


    public static class FindAllNotDeletedExtensions
    {
        public static List<T> FindAllNotDeleted<T>(this IQueryBuilder queryBuilder)
            where T : class, IHasId, IDummyDeletable, new()
        {
            return queryBuilder.For<List<T>>().With(new FindAllNotDeleted());
        }
    }
}