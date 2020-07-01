namespace Leads.WebApi.Test.Tests.Common.Api
{
    using System;
    using System.Net.Http;


    public class Api : IDisposable
    {
        private readonly HttpClient _client;


        public Api(HttpClient client)
        {
            _client = client;
            Account = new AccountApi(client);
            User = new UserApi(client);
        }


        public AccountApi Account { get; }

        public UserApi User { get; }


        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}