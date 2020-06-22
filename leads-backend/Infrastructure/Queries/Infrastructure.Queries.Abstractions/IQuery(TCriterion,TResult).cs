namespace Infrastructure.Queries.Abstractions
{
    using Criteria.Abstractions;


    public interface IQuery<in TCriterion, out TResult>
        where TCriterion : ICriterion
    {
        TResult Ask(TCriterion criterion);
    }
}