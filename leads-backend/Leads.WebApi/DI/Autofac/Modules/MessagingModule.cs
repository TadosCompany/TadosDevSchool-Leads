namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application.Infrastructure.Messaging;
    using global::Autofac;


    public class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<LoggerEmailMessageSender>()
                .As<IEmailMessageSender>()
                .InstancePerLifetimeScope();
        }
    }
}