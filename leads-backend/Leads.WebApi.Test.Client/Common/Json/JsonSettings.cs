namespace Leads.WebApi.Test.Client.Common.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;


    public static class JsonSettings
    {
        public static readonly JsonConverter[] Converters =
        {
            new StringEnumConverter(),
        };
    }
}