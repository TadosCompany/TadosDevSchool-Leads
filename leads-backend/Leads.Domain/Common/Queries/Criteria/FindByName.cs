namespace Leads.Domain.Common.Queries.Criteria
{
    using Infrastructure.Queries.Criteria.Abstractions;


    public class FindByName : ICriterion
    {
        public FindByName(string name)
        {
            Name = name;
        }


        public string Name { get; }
    }
}