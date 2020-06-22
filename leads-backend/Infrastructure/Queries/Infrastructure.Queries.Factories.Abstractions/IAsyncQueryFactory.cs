namespace Infrastructure.Queries.Factories.Abstractions
{
    using Criteria.Abstractions;
    using Queries.Abstractions;


    public interface IAsyncQueryFactory
    {
        IAsyncQuery<TCriterion, TResult> Create<TCriterion, TResult>()
            where TCriterion : ICriterion;
    }
}