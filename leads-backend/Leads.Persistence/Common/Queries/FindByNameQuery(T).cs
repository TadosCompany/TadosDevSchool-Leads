namespace Leads.Persistence.Common.Queries
{
    using System.Linq;
    using Domain.Common;
    using Domain.Common.Queries.Criteria;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindByNameQuery<T> : LinqQueryBase<T, FindByName, T>
        where T : class, IHasId, IHasName, new()
    {
        public FindByNameQuery(ILinqProvider linqProvider) : base(linqProvider)
        {
        }


        public override T Ask(FindByName criterion)
        {
            return Query.SingleOrDefault(x => x.Name == criterion.Name);
        }
    }
}