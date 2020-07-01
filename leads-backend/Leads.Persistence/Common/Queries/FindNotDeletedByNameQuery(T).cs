namespace Leads.Persistence.Common.Queries
{
    using System.Linq;
    using Domain.Common;
    using Domain.Common.Queries.Criteria;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindNotDeletedByNameQuery<T> : LinqQueryBase<T, FindNotDeletedByName, T>
        where T : class, IHasId, IDummyDeletable, IHasName, new()
    {
        public FindNotDeletedByNameQuery(ILinqProvider linqProvider) : base(linqProvider)
        {
        }


        public override T Ask(FindNotDeletedByName criterion)
        {
            return Query.SingleOrDefault(x => x.DeletedAtUtc == null && x.Name == criterion.Name);
        }
    }
}