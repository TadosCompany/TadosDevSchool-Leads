namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application;
    using Domain;
    using Events.Mappers.Abstractions;
    using global::Application.Events.Buses.Abstractions;
    using global::Application.Events.Buses.InMemory;
    using global::Application.Events.Mappers.Builders.Abstractions;
    using global::Application.Events.Mappers.Builders.Default;
    using global::Application.Events.Mappers.Default;
    using global::Application.Events.Mappers.Factories.Abstractions;
    using global::Application.Events.Stores.Processors.Abstractions;
    using global::Application.Events.Stores.Processors.AfterCommit;
    using global::Autofac;
    using global::Domain.Events.Dispatchers.Abstractions;
    using global::Domain.Events.Dispatchers.Default;
    using global::Domain.Events.HandlerBuilders.Abstractions;
    using global::Domain.Events.HandlerBuilders.Default;
    using global::Domain.Events.HandlerFactories.Abstractions;
    using global::Domain.Events.Handlers.Abstractions;
    using global::Domain.Events.Raisers.Abstractions;
    using global::Domain.Events.Raisers.Default;
    using global::Domain.Events.Stores.Abstractions;
    using global::Domain.Events.Stores.Default;
    using Tados.Autofac.Extensions.TypedFactories;

    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(DomainAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncDomainEventHandler<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IAsyncDomainEventHandlerFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncDomainEventHandlerBuilder>()
                .As<IAsyncDomainEventHandlerBuilder>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncDomainEventRaiser>()
                .As<IAsyncDomainEventRaiser>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncDomainEventDispatcher>()
                .As<IAsyncDomainEventDispatcher>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncDomainEventStore>()
                .As<IAsyncDomainEventStore>()
                .InstancePerLifetimeScope()
                .OnActivated(x => x.Context.Resolve<IAsyncDomainToApplicationEventStoreProcessor>());       // Dirty hack, AutoActivate() only works with singletones

            builder
                .RegisterGeneric(typeof(DefaultDomainToApplicationEventMapper<>))
                .As(typeof(IEventMapper<,,>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AsClosedTypesOf(typeof(IEventMapper<,,>))
                .InstancePerDependency();

            builder
                .RegisterRuntimeTypedFactory<IDomainToApplicationEventMapperFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultDomainToApplicationEventMapperBuilder>()
                .As<IDomainToApplicationEventMapperBuilder>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AsyncInMemoryApplicationEventBus>()
                .As<IAsyncApplicationEventBus>()
                .SingleInstance();

            builder
                .RegisterType<AfterCommitAsyncDomainToApplicationEventStoreProcessor>()
                .As<IAsyncDomainToApplicationEventStoreProcessor>()
                .InstancePerLifetimeScope();
                //.AutoActivate();    // Uncomment if Aoutofac would fix it - https://github.com/autofac/Autofac/issues/567
        }
    }
}
