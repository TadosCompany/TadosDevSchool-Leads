namespace Leads.WebApi.Test.Services
{
    using System;
    using System.Threading.Tasks;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;

    public class TestStartable : IStartable
    {
        private readonly IServiceProvider _serviceProvider;


        public TestStartable(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public void Start()
        {
            using var scope = _serviceProvider.CreateScope();

            var testInit = scope.ServiceProvider.GetService<TestDataSetInitializer>();

            // TODO : :(
            Task.Run(testInit.InitAsync).GetAwaiter().GetResult();
        }
    }
}