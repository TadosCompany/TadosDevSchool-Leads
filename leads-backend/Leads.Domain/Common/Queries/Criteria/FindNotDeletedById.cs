namespace Leads.Domain.Common.Queries.Criteria
{
    using Infrastructure.Queries.Criteria.Abstractions;


    public class FindNotDeletedById : ICriterion
    {
        public FindNotDeletedById(long id)
        {
            Id = id;
        }


        public long Id { get; }
    }
}