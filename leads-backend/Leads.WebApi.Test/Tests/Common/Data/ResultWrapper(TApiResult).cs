namespace Leads.WebApi.Test.Tests.Common.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Application.Infrastructure.Requests.Results;
    using Newtonsoft.Json.Linq;

    public class ResultWrapper<TApiResult> : ResultWrapper
        where TApiResult : IApiRequestResult
    {
        public ResultWrapper(string responseBody) : base(responseBody)
        {
        }

        public TApiResult GetResultData() => ResponseToken.ToObject<TApiResult>();

        public T GetPropertyValue<T>(Expression<Func<TApiResult, T>> getter)
        {
            try
            {
                var apiResultData = ResponseToken.ToObject<TApiResult>();
                return getter.Compile()(apiResultData);
            }
            catch
            {
                // ignore
            }

            Expression iterator = getter.Body;

            Stack<string> memberNames = new Stack<string>();

            while (iterator is MemberExpression memberExpression)
            {
                memberNames.Push(memberExpression.Member.Name);

                iterator = memberExpression.Expression;
            }

            JToken iteratorToken = ResponseToken;

            while (memberNames.Count > 0)
            {
                var memberName = memberNames.Pop();

                if (iteratorToken is JObject iteratorObject)
                {
                    if (iteratorObject.ContainsKey(memberName))
                    {
                        iteratorToken = iteratorObject[memberName];
                    }
                    else
                    {
                        // try to access field through camelCase
                        memberName = memberName.Substring(0, 1).ToLowerInvariant() + memberName.Substring(1);

                        if (iteratorObject.ContainsKey(memberName))
                        {
                            iteratorToken = iteratorObject[memberName];
                        }
                        else
                        {
                            return default;
                        }
                    }
                }
            }

            return iteratorToken.ToObject<T>();
        }
    }
}