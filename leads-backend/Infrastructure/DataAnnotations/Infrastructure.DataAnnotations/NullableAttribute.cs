namespace Infrastructure.DataAnnotations
{
    using System;


    [AttributeUsage(AttributeTargets.Property)]
    public class NullableAttribute : Attribute
    {
    }
}