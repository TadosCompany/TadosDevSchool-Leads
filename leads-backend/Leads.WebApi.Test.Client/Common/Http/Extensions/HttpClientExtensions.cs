namespace Leads.WebApi.Test.Client.Common.Http.Extensions
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Json;
    using Newtonsoft.Json;
    using Results;

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

        public static async Task<ResultWrapper<T>> ToResultAsync<T>(
            this HttpResponseMessage responseMessage)
        {
            return new ResultWrapper<T>(await responseMessage.Content.ReadAsStringAsync());
        }

        private static HttpContent CreateContent<T>(this T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data, JsonSettings.Converters));

            content.Headers.ContentType = MediaTypeHeaderValue.Parse(System.Net.Mime.MediaTypeNames.Application.Json);

            return content;
        }
    }
}