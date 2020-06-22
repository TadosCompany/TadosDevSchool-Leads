namespace Leads.Persistence.Common.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Criteria.Common;
    using Infrastructure.Queries.Repository.Base;
    using Infrastructure.Repositories.Abstractions;


    public class FindAllObjectsWithIdAsyncQuery<THasId> : RepositoryAsyncQueryBase<THasId, FindAll, List<THasId>>
        where THasId : class, IHasId, new()
    {
        public FindAllObjectsWithIdAsyncQuery(IAsyncRepository<THasId> repository) : base(repository)
        {
        }


        public override Task<List<THasId>> AskAsync(FindAll criterion,
            CancellationToken cancellationToken = default)
        {
            return Repository.GetAllAsync(cancellationToken);
        }
    }
}