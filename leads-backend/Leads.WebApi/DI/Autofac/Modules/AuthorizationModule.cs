namespace Leads.WebApi.DI.Autofac.Modules
{
    using Application;
    using Application.Authorization;
    using Application.Infrastructure.Authentication;
    using Application.Infrastructure.Authorization.Providers;
    using Domain.Users.Objects.Entities;
    using global::Autofac;
    using global::Microsoft.AspNetCore.Authorization;


    public class AuthorizationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<IdClaimBasedUserProvider<User>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<IdClaimBasedCookieAuthenticationService<User>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .WithParameter("scheme", Schemes.UserScheme);

            builder.RegisterAssemblyTypes(typeof(WebApiApplicationMarker).Assembly)
                .AssignableTo<IAuthorizationHandler>()
                .As<IAuthorizationHandler>()
                .InstancePerLifetimeScope();
        }
    }
}