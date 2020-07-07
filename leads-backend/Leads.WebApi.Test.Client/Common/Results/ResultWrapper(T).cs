namespace Leads.WebApi.Test.Client.Common.Results
{
    using System;

    public class ResultWrapper<T> : ResultWrapper
    {
        public ResultWrapper(string responseBody) : base(responseBody)
        {
        }


        public T GetResultData() => ResponseToken.ToObject<T>();

        public TValue GetPropertyValue<TValue>(Func<T, TValue> getter) => getter(GetResultData());
    }
}