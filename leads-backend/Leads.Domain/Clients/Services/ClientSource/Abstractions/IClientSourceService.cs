namespace Leads.Domain.Clients.Services.ClientSource.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Domain.Services.Abstractions;
    using Objects.Entities;


    public interface IClientSourceService : IDomainService
    {
        Task CreateAsync(ClientSource clientSource, CancellationToken cancellationToken = default);

        Task EditAsync(ClientSource clientSource, string name, CancellationToken cancellationToken = default);

        Task RestoreAsync(ClientSource clientSource, CancellationToken cancellationToken = default);
    }
}