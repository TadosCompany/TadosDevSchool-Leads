namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application.Infrastructure.Security.Passwords;
    using global::Autofac;


    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
#if DEBUG
            builder
                .RegisterType<DummyPasswordGenerator>()
                .As<IPasswordGenerator>()
                .SingleInstance();
#endif
        }
    }
}