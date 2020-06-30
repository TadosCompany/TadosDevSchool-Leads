namespace Leads.Persistence.Common.Queries
{
    using System.Linq;
    using Domain.Common;
    using Domain.Common.Queries.Criteria;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindNotDeletedByIdQuery<T> : LinqQueryBase<T, FindNotDeletedById, T>
        where T : class, IHasId, IDummyDeletable, new()
    {
        public FindNotDeletedByIdQuery(
            ILinqProvider linqProvider) : base(linqProvider)
        {
        }


        public override T Ask(FindNotDeletedById criterion)
        {
            return Query.SingleOrDefault(x => x.Id == criterion.Id && x.DeletedAtUtc == null);
        }
    }
}