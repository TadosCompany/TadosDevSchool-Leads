namespace Infrastructure.Linq.Providers.Abstractions
{
    using System.Linq;
    using Identification.Abstractions;


    public interface ILinqProvider
    {
        IQueryable<THasId> Query<THasId>()
            where THasId : class, IHasId, new();
    }
}