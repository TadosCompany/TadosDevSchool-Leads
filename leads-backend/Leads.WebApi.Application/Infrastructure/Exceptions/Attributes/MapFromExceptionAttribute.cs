namespace Leads.WebApi.Application.Infrastructure.Exceptions.Attributes
{
    using System;


    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class MapFromExceptionAttribute : Attribute
    {
        public MapFromExceptionAttribute(Type sourceExceptionType)
        {
            SourceExceptionType = sourceExceptionType ?? throw new ArgumentNullException(nameof(sourceExceptionType));
        }


        public Type SourceExceptionType { get; }
    }
}