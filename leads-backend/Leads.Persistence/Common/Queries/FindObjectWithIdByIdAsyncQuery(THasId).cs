namespace Leads.Persistence.Common.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Criteria.Common;
    using Infrastructure.Queries.Repository.Base;
    using Infrastructure.Repositories.Abstractions;


    public class FindObjectWithIdByIdAsyncQuery<THasId> : RepositoryAsyncQueryBase<THasId, FindById, THasId>
        where THasId : class, IHasId, new()
    {
        public FindObjectWithIdByIdAsyncQuery(IAsyncRepository<THasId> repository) : base(repository)
        {
        }


        public override Task<THasId> AskAsync(FindById criterion, CancellationToken cancellationToken = default)
        {
            return Repository.GetByIdAsync(criterion.Id, cancellationToken);
        }
    }
}