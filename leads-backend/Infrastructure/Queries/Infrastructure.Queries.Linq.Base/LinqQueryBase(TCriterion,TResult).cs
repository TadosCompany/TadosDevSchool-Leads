namespace Infrastructure.Queries.Linq.Base
{
    using System;
    using System.Linq;
    using Abstractions;
    using Criteria.Abstractions;
    using Identification.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;


    public abstract class LinqQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linqProvider;


        protected LinqQueryBase(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider ?? throw new ArgumentNullException(nameof(linqProvider));
        }


        protected virtual IQueryable<THasId> Query<THasId>()
            where THasId : class, IHasId, new()
            => _linqProvider.Query<THasId>();


        public abstract TResult Ask(TCriterion criterion);
    }
}