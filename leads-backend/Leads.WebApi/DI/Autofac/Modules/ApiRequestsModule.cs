namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application;
    using Application.Infrastructure.Requests.Handlers;
    using Application.Infrastructure.Requests.Handlers.Factories;
    using global::Autofac;
    using global::Autofac.Extensions.TypedFactories;


    public class ApiRequestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AsClosedTypesOf(typeof(IApiRequestHandler<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AsClosedTypesOf(typeof(IApiRequestHandler<,>))
                .InstancePerDependency();
            
            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncApiRequestHandler<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncApiRequestHandler<,>))
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IApiRequestHandlerFactory>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}