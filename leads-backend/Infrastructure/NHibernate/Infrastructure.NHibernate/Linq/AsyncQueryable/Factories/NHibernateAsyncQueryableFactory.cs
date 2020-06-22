namespace Infrastructure.NHibernate.Linq.AsyncQueryable.Factories
{
    using System.Linq;
    using Infrastructure.Linq.AsyncQueryable.Abstractions;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;


    public class NHibernateAsyncQueryableFactory : IAsyncQueryableFactory
    {
        public IAsyncQueryable<T> CreateFrom<T>(IQueryable<T> query)
        {
            return new NHibernateAsyncQueryable<T>(query);
        }
    }
}