namespace Infrastructure.Queries.Factories.Abstractions
{
    using Criteria.Abstractions;
    using Queries.Abstractions;


    public interface IQueryFactory
    {
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>()
            where TCriterion : ICriterion;
    }
}