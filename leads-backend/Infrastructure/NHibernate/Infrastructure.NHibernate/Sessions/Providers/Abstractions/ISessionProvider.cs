namespace Infrastructure.NHibernate.Sessions.Providers.Abstractions
{
    using global::NHibernate;


    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}