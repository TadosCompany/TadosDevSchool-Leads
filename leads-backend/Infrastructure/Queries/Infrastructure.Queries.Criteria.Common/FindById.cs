namespace Infrastructure.Queries.Criteria.Common
{
    using Abstractions;


    public class FindById : ICriterion
    {
        public FindById(long id)
        {
            Id = id;
        }


        public long Id { get; }
    }
}