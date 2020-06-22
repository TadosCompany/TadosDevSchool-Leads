namespace Infrastructure.NHibernate.AutoMapping.Conventions.Abstractions
{
    using System;
    using System.Reflection;
    using Extensions;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;


    public abstract class AttributePropertyConvention<TAttribute> : IPropertyConventionAcceptance, IPropertyConvention
        where TAttribute : Attribute
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            AcceptIf(criteria.Expect(inspector => inspector.Property.HasAttribute<TAttribute>()));
        }

        public void Apply(IPropertyInstance instance)
        {
            Apply(instance, instance.Property.MemberInfo.GetCustomAttribute<TAttribute>());
        }


        protected virtual void AcceptIf(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
        }

        protected abstract void Apply(IPropertyInstance instance, TAttribute attribute);
    }
}