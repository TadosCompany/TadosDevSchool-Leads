namespace Leads.WebApi.DI.Autofac.Modules
{
    using global::Autofac;
    using global::Autofac.Extensions.TypedFactories;
    using Infrastructure.Commands.Abstractions;
    using Infrastructure.Commands.Builders.Abstractions;
    using Infrastructure.Commands.Builders.Default;
    using Infrastructure.Commands.Factories.Abstractions;
    using Persistence;
    using Persistence.Common.Commands;


    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CreateObjectWithIdRepositoryAsyncCommand<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(DeleteObjectWithIdRepositoryAsyncCommand<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(ICommand<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncCommand<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<ICommandFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncCommandFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CommandBuilder>()
                .As<ICommandBuilder>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AsyncCommandBuilder>()
                .As<IAsyncCommandBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}