namespace Leads.WebApi.Test.Tests.Common.Api
{
    using System;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Infrastructure.Requests.Results;
    using Data;
    using Extensions;


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

        public async Task<ErrorDto> GetErrorAsync()
        {
            return (await GetResultAsync()).GetError();
        }

        public void Dispose()
        {
            _resultWrapperTask?.Dispose();
            HttpResponse?.Dispose();
        }
    }

    public class ApiResult<TApiResult> : IDisposable
        where TApiResult : IApiRequestResult
    {
        private Task<ResultWrapper<TApiResult>> _resultWrapperTask;

        public ApiResult(HttpResponseMessage httpResponse)
        {
            HttpResponse = httpResponse;
        }

        public HttpResponseMessage HttpResponse { get; }


        public Task<ResultWrapper<TApiResult>> GetResultAsync()
        {
            return _resultWrapperTask ??= HttpResponse.ToResultAsync<TApiResult>();
        }

        public async Task<T> GetPropertyValueAsync<T>(Expression<Func<TApiResult, T>> getter)
        {
            return (await GetResultAsync()).GetPropertyValue(getter);
        }

        public async Task<TApiResult> GetResultDataAsync()
        {
            return (await GetResultAsync()).GetResultData();
        }

        public async Task<ErrorDto> GetErrorAsync()
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