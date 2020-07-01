namespace Leads.WebApi.Test.Tests.Common.Extensions
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Application.Infrastructure.Requests.Results;
    using Data;
    using Newtonsoft.Json;

    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> SendApiRequestAsync<TRequest>(
            this HttpClient client,
            string url,
            TRequest request)
        {
            using var content = request.CreateContent();

            return client.PostAsync(url, content);
        }

        public static async Task<ResultWrapper> ToResultAsync(this HttpResponseMessage responseMessage)
        {
            return new ResultWrapper(await responseMessage.Content.ReadAsStringAsync());
        }

        public static async Task<ResultWrapper<TApiResult>> ToResultAsync<TApiResult>(
            this HttpResponseMessage responseMessage)
            where TApiResult : IApiRequestResult
        {
            return new ResultWrapper<TApiResult>(await responseMessage.Content.ReadAsStringAsync());
        }

        private static HttpContent CreateContent<T>(this T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = MediaTypeHeaderValue.Parse(System.Net.Mime.MediaTypeNames.Application.Json);

            return content;
        }
    }
}