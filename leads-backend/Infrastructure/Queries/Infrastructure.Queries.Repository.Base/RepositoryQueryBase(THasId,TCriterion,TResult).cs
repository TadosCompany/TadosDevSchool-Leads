namespace Infrastructure.Queries.Repository.Base
{
    using Abstractions;
    using Criteria.Abstractions;
    using Identification.Abstractions;
    using Repositories.Abstractions;


    public abstract class RepositoryQueryBase<THasId, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where THasId : class, IHasId, new()
        where TCriterion : ICriterion
    {
        protected RepositoryQueryBase(IRepository<THasId> repository)
        {
            Repository = repository;
        }


        protected IRepository<THasId> Repository { get; }


        public abstract TResult Ask(TCriterion criterion);
    }
}