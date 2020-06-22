namespace Infrastructure.NHibernate.AutoMapping.Conventions.Constraints
{
    using Abstractions;
    using DataAnnotations;
    using FluentNHibernate.Conventions.Instances;
    using Naming;


    public class UniqueConvention : AttributePropertyConvention<UniqueAttribute>
    {
        protected override void Apply(IPropertyInstance instance, UniqueAttribute attribute)
        {
            bool isClustered = attribute.Key != null;

            string uniqueKeyName = isClustered
                ? $"{NamingConstants.UniqueClusteredKeyPrefix}_{attribute.Key}"
                : $"{NamingConstants.UniqueKeyPrefix}_{instance.Name}";

            uniqueKeyName = uniqueKeyName.Truncate();

            instance.UniqueKey(uniqueKeyName);
        }
    }
}