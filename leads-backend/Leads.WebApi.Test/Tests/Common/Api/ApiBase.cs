namespace Leads.WebApi.Test.Tests.Common.Api
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Infrastructure.Requests;
    using Application.Infrastructure.Requests.Results;
    using Extensions;

    public abstract class ApiBase
    {
        private readonly HttpClient _client;


        protected ApiBase(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        protected async Task<ApiResult> MakeRequestAsync<TRequest>(string url, TRequest request)
            where TRequest : IApiRequest
        {
            return new ApiResult(await _client.SendApiRequestAsync(url, request));
        }

        protected async Task<ApiResult<TResult>> MakeRequestAsync<TRequest, TResult>(string url, TRequest request)
            where TRequest : IApiRequest<TResult>
            where TResult : IApiRequestResult
        {
            return new ApiResult<TResult>(await _client.SendApiRequestAsync(url, request));
        }
    }
}