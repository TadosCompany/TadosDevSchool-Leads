namespace Leads.Persistence.Common.Queries
{
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Queries.Criteria.Common;
    using Infrastructure.Queries.Repository.Base;
    using Infrastructure.Repositories.Abstractions;


    public class FindObjectWithIdByIdQuery<THasId> : RepositoryQueryBase<THasId, FindById, THasId>
        where THasId : class, IHasId, new()
    {
        public FindObjectWithIdByIdQuery(IRepository<THasId> repository) : base(repository)
        {
        }


        public override THasId Ask(FindById criterion)
        {
            return Repository.GetById(criterion.Id);
        }
    }
}