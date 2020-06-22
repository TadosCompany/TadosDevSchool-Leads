namespace Infrastructure.Linq.AsyncQueryable.Factories.Abstractions
{
    using System.Linq;
    using AsyncQueryable.Abstractions;


    public interface IAsyncQueryableFactory
    {
        IAsyncQueryable<T> CreateFrom<T>(IQueryable<T> query);
    }
}