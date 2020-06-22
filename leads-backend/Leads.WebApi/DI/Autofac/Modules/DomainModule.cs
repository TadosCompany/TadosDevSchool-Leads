namespace Leads.WebApi.DI.Autofac.Modules
{
    using Domain;
    using global::Autofac;
    using Infrastructure.Domain.Services.Abstractions;


    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(DomainAssemblyMarker).Assembly)
                .AssignableTo<IDomainService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}