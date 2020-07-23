namespace Leads.Domain.Users.Services.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Enums;
    using Infrastructure.Domain.Services.Abstractions;
    using Objects.Entities;


    public interface IUserService : IDomainService
    {
        Task<User> CreateAsync(string email, string password, UserRoles role, CancellationToken cancellationToken = default);

        Task EditAsync(User user, string email, UserRoles role, CancellationToken cancellationToken = default);

        Task RestoreAsync(User user, CancellationToken cancellationToken = default);

        Task ResetPasswordAsync(User user, string password, CancellationToken cancellationToken = default);
    }
}