namespace Infrastructure.Queries.Builders.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Criteria.Abstractions;

    
    public interface IAsyncQueryFor<TResult>
    {
        Task<TResult> WithAsync<TCriterion>(TCriterion criterion, CancellationToken cancellationToken = default)
            where TCriterion : ICriterion;
    }
}