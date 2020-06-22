namespace Infrastructure.Repositories.Abstractions
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Identification.Abstractions;


    public interface IAsyncRepository<THasId>
        where THasId : class, IHasId, new()
    {
        Task<List<THasId>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(THasId objectWithId, CancellationToken cancellationToken = default);

        Task<THasId> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task DeleteAsync(THasId objectWithId, CancellationToken cancellationToken = default);
    }
}