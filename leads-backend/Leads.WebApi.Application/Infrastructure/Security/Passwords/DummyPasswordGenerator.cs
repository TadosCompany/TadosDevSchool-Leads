#if DEBUG
namespace Leads.WebApi.Application.Infrastructure.Security.Passwords
{
    using System;


    public class DummyPasswordGenerator : IPasswordGenerator
    {
        private static readonly Random Random = new Random();


        public string Generate()
        {
            return $"password{Random.Next(0, 10000):D5}";
        }
    }
}
#endif