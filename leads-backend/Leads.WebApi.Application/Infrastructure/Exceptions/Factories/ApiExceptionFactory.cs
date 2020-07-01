namespace Leads.WebApi.Application.Infrastructure.Exceptions.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Abstractions;
    using Attributes;
    using Domain.Exceptions;


    public class ApiExceptionFactory : IApiExceptionFactory
    {
        #region Static members

        private static readonly Dictionary<ErrorCodes, string> DefaultMessages = new Dictionary<ErrorCodes, string>();
        private static readonly Dictionary<Type, ErrorCodes> ExceptionCodes = new Dictionary<Type, ErrorCodes>();

        static ApiExceptionFactory()
        {
            var type = typeof(ErrorCodes);
            var codes = type.GetEnumValues().Cast<ErrorCodes>();

            foreach (var code in codes)
            {
                var field = type.GetField(code.ToString());

                if (field != null)
                {
                    var defaultMessageAttribute = field.GetCustomAttribute<DefaultMessageAttribute>();

                    if (defaultMessageAttribute != null)
                        DefaultMessages[code] = defaultMessageAttribute.Message;

                    var mapAttributes = field.GetCustomAttributes<MapFromExceptionAttribute>();

                    foreach (var mapAttribute in mapAttributes)
                    {
                        ExceptionCodes[mapAttribute.SourceExceptionType] = code;
                    }
                }
            }
        }

        #endregion

        public ApiException Create(ErrorCodes code)
        {
            if (!DefaultMessages.TryGetValue(code, out string message))
            {
                message = code.ToString();
            }

            return new ApiException(code, message);
        }

        public ApiException Create(ErrorCodes code, Exception innerException)
        {
            if (!DefaultMessages.TryGetValue(code, out string message))
            {
                message = code.ToString();
            }

            return new ApiException(code, message, innerException);
        }

        public ApiException MapException(DomainException exception)
        {
            if (!ExceptionCodes.TryGetValue(exception.GetType(), out ErrorCodes code))
            {
                code = ErrorCodes.UnknownError;
            }

            return Create(code, exception);
        }
    }
}