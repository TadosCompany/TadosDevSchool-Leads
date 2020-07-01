namespace Leads.WebApi.Test.AspNetCore
{
    using Autofac;
    using DI.Autofac;
    using Microsoft.Extensions.Configuration;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            base.ConfigureContainer(containerBuilder);

            containerBuilder.RegisterModule<TestModule>();
        }
    }
}