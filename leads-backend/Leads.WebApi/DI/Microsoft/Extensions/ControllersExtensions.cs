namespace Leads.WebApi.DI.Microsoft.Extensions
{
    using Application;
    using Application.Infrastructure.Filters;
    using FluentValidation.AspNetCore;
    using global::Microsoft.Extensions.DependencyInjection;

    public static class ControllersExtensions
    {
        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services
                .AddControllers(options => options.Filters.Add(typeof(ValidationActionFilter)))
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssemblyContaining<WebApiApplicationMarker>())
                .AddNewtonsoftJson();
            
            return services;
        }
    }
}