namespace Leads.WebApi.Application.Infrastructure.Authentication
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAuthenticationService<in TUser>
    {
        Task SignInAsync(TUser user, CancellationToken cancellationToken = default);

        Task SignOutAsync(CancellationToken cancellationToken = default);
    }
}