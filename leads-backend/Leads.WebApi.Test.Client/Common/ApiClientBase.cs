namespace Leads.WebApi.Test.Client.Common
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Http.Extensions;
    using Results;


    public abstract class ApiClientBase
    {
        private readonly HttpClient _client;


        protected ApiClientBase(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        protected async Task<ApiResult> MakeRequestAsync<TRequest>(string url, TRequest request)
        {
            return new ApiResult(await _client.SendApiRequestAsync(url, request));
        }

        protected async Task<ApiResult<TResult>> MakeRequestAsync<TRequest, TResult>(string url, TRequest request)
        {
            return new ApiResult<TResult>(await _client.SendApiRequestAsync(url, request));
        }
    }
}