namespace Leads.WebApi.Application.Infrastructure.Authorization.Providers
{
    public abstract class UserProviderBase<TUser> : IUserProvider<TUser>
    {
        public TUser User => GetUser();


        protected abstract TUser GetUser();
    }
}