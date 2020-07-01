namespace Leads.Domain.Common.Queries.Criteria
{
    using Infrastructure.Queries.Criteria.Abstractions;

    
    
    public class FindNotDeletedByName : ICriterion
    {
        public FindNotDeletedByName(string name)
        {
            Name = name;
        }
        
        
        public string Name { get; }
    }
}