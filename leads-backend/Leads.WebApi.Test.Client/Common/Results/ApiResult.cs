namespace Leads.WebApi.Test.Client.Common.Results
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Errors;
    using Http.Extensions;

    public class ApiResult : IDisposable
    {
        private Task<ResultWrapper> _resultWrapperTask;


        public ApiResult(HttpResponseMessage httpResponse)
        {
            HttpResponse = httpResponse;
        }


        public HttpResponseMessage HttpResponse { get; }


        public Task<ResultWrapper> GetResultAsync()
        {
            return _resultWrapperTask ??= HttpResponse.ToResultAsync();
        }

        public async Task<Error> GetErrorAsync()
        {
            return (await GetResultAsync()).GetError();
        }

        public void Dispose()
        {
            _resultWrapperTask?.Dispose();
            HttpResponse?.Dispose();
        }
    }
}