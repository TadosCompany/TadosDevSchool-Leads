namespace Leads.WebApi.DI.Microsoft.Extensions
{
    using Application;
    using Application.Infrastructure.Filters;
    using FluentValidation.AspNetCore;
    using global::Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    public static class ControllersExtensions
    {
        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services
                .AddControllers(options => options.Filters.Add(typeof(ValidationActionFilter)))
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssemblyContaining<WebApiApplicationMarker>())
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(
                        new StringEnumConverter(
                            new DefaultNamingStrategy(),
                            allowIntegerValues: false));
                });

            return services;
        }
    }
}