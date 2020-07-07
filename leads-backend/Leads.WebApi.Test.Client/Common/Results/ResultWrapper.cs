namespace Leads.WebApi.Test.Client.Common.Results
{
    using Errors;
    using Json;
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


        protected JToken ResponseToken => _responseToken ??= JsonConvert.DeserializeObject<JToken>(_responseBody, JsonSettings.Converters);


        public Error GetError()
        {
            return ResponseToken.ToObject<Error>();
        }
    }
}