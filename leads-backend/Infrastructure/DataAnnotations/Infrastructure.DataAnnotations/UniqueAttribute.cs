namespace Infrastructure.DataAnnotations
{
    using System;


    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueAttribute : Attribute
    {
        public UniqueAttribute(string key = null)
        {
            Key = key;
        }


        public string Key { get; }
    }
}