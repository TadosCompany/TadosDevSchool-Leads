namespace Leads.WebApi.Test.DI.Autofac
{
    using global::Autofac;
    using NHibernate;
    using Persistence.NHibernate;
    using Services;

    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<TestNHibernateInitializer>()
                .As<NHibernateInitializer>()
                .SingleInstance();

            builder
                .RegisterType<TestDataSetInitializer>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TestStartable>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}