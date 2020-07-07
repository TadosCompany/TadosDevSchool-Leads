namespace Leads.WebApi.Test.Client.Common.Results
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Errors;
    using Http.Extensions;

    public class ApiResult<T> : IDisposable
    {
        private Task<ResultWrapper<T>> _resultWrapperTask;


        public ApiResult(HttpResponseMessage httpResponse)
        {
            HttpResponse = httpResponse;
        }

        public HttpResponseMessage HttpResponse { get; }


        public Task<ResultWrapper<T>> GetResultAsync()
        {
            return _resultWrapperTask ??= HttpResponse.ToResultAsync<T>();
        }

        public async Task<TValue> GetPropertyValueAsync<TValue>(Func<T, TValue> getter)
        {
            return (await GetResultAsync()).GetPropertyValue(getter);
        }

        public async Task<T> GetResultDataAsync()
        {
            return (await GetResultAsync()).GetResultData();
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