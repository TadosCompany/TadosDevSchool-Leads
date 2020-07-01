namespace Leads.WebApi.DI.Microsoft.Extensions
{
    using global::Microsoft.Extensions.DependencyInjection;
    using global::Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Swagger;


    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "Leads API",
                        Version = "v1",
                    });
                
                options.AddSecurityDefinition(
                    name: "Cookie",
                    securityScheme: new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Cookie,
                        Name = "LeadsUserCookie",
                    });

                options.CustomSchemaIds(x => x.FullName);
                
                options.AddFluentValidationRules();
            }).AddSwaggerGenNewtonsoftSupport();

            return services;
        }
    }
}