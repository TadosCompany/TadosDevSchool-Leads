namespace Leads.WebApi.Test.Client
{
    using System;
    using System.Net.Http;
    using Account;
    using Users;

    public class ApiClient : IDisposable
    {
        private readonly HttpClient _client;


        public ApiClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            Account = new AccountApi(_client);
            User = new UserApi(_client);
        }


        public AccountApi Account { get; }

        public UserApi User { get; }


        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}