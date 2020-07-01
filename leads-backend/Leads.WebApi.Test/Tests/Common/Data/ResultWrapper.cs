namespace Leads.WebApi.Test.Tests.Common.Data
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class ResultWrapper
    {
        private readonly string _responseBody;
        private JToken _responseToken;


        public ResultWrapper(string responseBody)
        {
            _responseBody = responseBody;
        }


        protected JToken ResponseToken => _responseToken ??= JsonConvert.DeserializeObject<JToken>(_responseBody);


        public ErrorDto GetError()
        {
            return ResponseToken.ToObject<ErrorDto>();
        }
    }
}