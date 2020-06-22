namespace Infrastructure.Queries.Builders.Abstractions
{
    public interface IQueryBuilder
    {
        IQueryFor<TResult> For<TResult>();
    }
}