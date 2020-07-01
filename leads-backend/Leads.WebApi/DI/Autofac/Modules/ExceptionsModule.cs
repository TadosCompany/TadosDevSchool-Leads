namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application.Infrastructure.Exceptions.Factories;
    using Application.Infrastructure.Exceptions.Factories.Abstractions;
    using global::Autofac;


    public class ExceptionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ApiExceptionFactory>()
                .As<IApiExceptionFactory>()
                .SingleInstance();
        }
    }
}