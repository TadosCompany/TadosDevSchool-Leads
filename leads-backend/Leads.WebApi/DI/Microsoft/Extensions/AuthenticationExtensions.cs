namespace Leads.WebApi.DI.Microsoft.Extensions
{
    using System.Threading.Tasks;
    using Application.Authorization;
    using global::Microsoft.AspNetCore.Authentication.Cookies;
    using global::Microsoft.Extensions.DependencyInjection;


    public static class AuthenticationExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication()
                .AddCookie(Schemes.UserScheme, options =>
                {
                    options.Cookie.Name = "LeadsUserCookie";
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
    }
}