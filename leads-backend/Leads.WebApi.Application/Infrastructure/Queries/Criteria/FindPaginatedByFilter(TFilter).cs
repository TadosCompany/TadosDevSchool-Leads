namespace Leads.WebApi.Application.Infrastructure.Queries.Criteria
{
    using global::Infrastructure.Queries.Criteria.Abstractions;


    public class FindPaginatedByFilter<TFilter> : ICriterion
    {
        public FindPaginatedByFilter(int offset, int count, TFilter filter)
        {
            Offset = offset;
            Count = count;
            Filter = filter;
        }


        public int Offset { get; }

        public int Count { get; }

        public TFilter Filter { get; }
    }
}