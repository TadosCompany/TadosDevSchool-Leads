namespace Infrastructure.Queries.Linq.Base
{
    using System;
    using System.Linq;
    using Abstractions;
    using Criteria.Abstractions;
    using Identification.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;


    public abstract class LinqQueryBase<THasId, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where THasId : class, IHasId, new()
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;


        protected LinqQueryBase(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider ?? throw new ArgumentNullException(nameof(linqProvider));
        }


        protected virtual IQueryable<THasId> Query => _linqProvider.Query<THasId>();


        public abstract TResult Ask(TCriterion criterion);
    }
}