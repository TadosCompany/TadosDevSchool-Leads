namespace Infrastructure.Queries.Builders.Abstractions
{
    using Criteria.Abstractions;


    public interface IQueryFor<out TResult>
    {
        TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
    }
}