namespace Leads.WebApi.Application.Infrastructure.Authorization.Providers
{
    public interface IUserProvider<out TUser>
    {
        TUser User { get; }
    }
}