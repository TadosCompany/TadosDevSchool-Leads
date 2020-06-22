namespace Infrastructure.Queries.Repository.Base
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Criteria.Abstractions;
    using Identification.Abstractions;
    using Repositories.Abstractions;


    public abstract class RepositoryAsyncQueryBase<THasId, TCriterion, TResult> : IAsyncQuery<TCriterion, TResult>
        where THasId : class, IHasId, new()
        where TCriterion : ICriterion
    {
        protected RepositoryAsyncQueryBase(IAsyncRepository<THasId> repository)
        {
            Repository = repository;
        }


        protected IAsyncRepository<THasId> Repository { get; }


        public abstract Task<TResult> AskAsync(TCriterion criterion, CancellationToken cancellationToken = default);
    }
}