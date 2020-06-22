namespace Infrastructure.Queries.Builders.Abstractions
{
    public interface IAsyncQueryBuilder
    {
        IAsyncQueryFor<TResult> For<TResult>();
    }
}