namespace Leads.WebApi.DI.Microsoft.Extensions
{
    using Application;
    using AutoMapper;
    using global::Microsoft.Extensions.DependencyInjection;


    public static class AutoMapperExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(WebApiApplicationMarker).Assembly);

            return services;
        }
    }
}