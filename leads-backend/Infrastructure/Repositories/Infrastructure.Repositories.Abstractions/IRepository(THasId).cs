namespace Infrastructure.Repositories.Abstractions
{
    using System.Collections.Generic;
    using Identification.Abstractions;


    public interface IRepository<THasId>
        where THasId : class, IHasId, new()
    {
        List<THasId> GetAll();
        
        void Add(THasId objectWithId);

        THasId GetById(long id);

        void Delete(THasId objectWithId);
    }
}