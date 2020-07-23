namespace Leads.WebApi
{
    using Application.Infrastructure.HostedServices;
    using Autofac;
    using Autofac.Extensions.ConfiguredModules;
    using DI.Microsoft.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterConfiguredModulesFromCurrentAssembly(Configuration);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddHostedService<EmailSenderHostedService>();

            services
                .ConfigureControllers()
                .ConfigureAuthentication()
                .ConfigureAuthorization()
                .ConfigureAutoMapper()
                .ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Leads API"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area}/{controller}/{action}");
            });

        }
    }
}