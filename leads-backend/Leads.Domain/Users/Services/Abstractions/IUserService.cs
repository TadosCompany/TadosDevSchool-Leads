namespace Leads.Domain.Users.Services.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Domain.Services.Abstractions;
    using Objects.Entities;


    public interface IUserService : IDomainService
    {
        Task CreateAsync(User user, CancellationToken cancellationToken = default);
    }
}