namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application.Persistence;
    using global::Autofac;
    using global::Autofac.Extensions.TypedFactories;
    using Infrastructure.Queries.Abstractions;
    using Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Queries.Builders.Default;
    using Infrastructure.Queries.Factories.Abstractions;
    using Persistence;
    using Persistence.Common.Queries;


    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(FindAllObjectsWithIdAsyncQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindObjectWithIdByIdQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindObjectWithIdByIdAsyncQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindAllNotDeletedAsyncQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindNotDeletedByIdAsyncQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FindNotDeletedByIdQuery<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IQuery<,>))
                .InstancePerDependency();
            
            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();
            
            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationPersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IQuery<,>))
                .InstancePerDependency();
            
            builder
                .RegisterAssemblyTypes(typeof(WebApiApplicationPersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(QueryFor<>))
                .As(typeof(IQueryFor<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(AsyncQueryFor<>))
                .As(typeof(IAsyncQueryFor<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IQueryFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IQueryBuilder>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}