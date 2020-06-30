namespace Leads.WebApi.DI.Autofac.Modules
{
    using global::Autofac;
    using global::Autofac.Extensions.ConfiguredModules;
    using global::Microsoft.Extensions.Configuration;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.NHibernate.Linq.AsyncQueryable.Factories;
    using Infrastructure.NHibernate.Linq.Providers;
    using Infrastructure.NHibernate.Repositories;
    using Infrastructure.NHibernate.Sessions.Providers;
    using Infrastructure.NHibernate.Sessions.Providers.Abstractions;
    using Infrastructure.Repositories.Abstractions;
    using Infrastructure.Transactions.Behaviors;
    using Infrastructure.Transactions.Notifications.Abstractions;
    using Persistence.NHibernate;


    public class NHibernateModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(NHibernateRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
            
            builder
                .RegisterGeneric(typeof(NHibernateAsyncRepository<>))
                .As(typeof(IAsyncRepository<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateLinqProvider>()
                .As<ILinqProvider>()
                .InstancePerLifetimeScope();
            
            builder
                .RegisterType<ExpectCommitScopedSessionProvider>()
                .As<ISessionProvider>()
                .As<IExpectCommit>()
                .As<ICommitNotifier>()
                .As<IRollbackNotifier>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateAsyncQueryableFactory>()
                .As<IAsyncQueryableFactory>()
                .InstancePerLifetimeScope();

            var connectionString = Configuration.GetConnectionString("Leads");

            builder
                .RegisterType<NHibernateInitializer>()
                .AsSelf()
                .SingleInstance()
                .WithParameter("connectionString", connectionString);

            builder
                .Register(context => context.Resolve<NHibernateInitializer>().GetConfiguration().BuildSessionFactory())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}