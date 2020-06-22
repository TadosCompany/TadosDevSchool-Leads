namespace Infrastructure.DataAnnotations
{
    using System;


    [AttributeUsage(AttributeTargets.Property)]
    public class UtcDateTimeAttribute : Attribute
    {
    }
}