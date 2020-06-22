namespace Infrastructure.NHibernate.AutoMapping.Conventions.Types
{
    using System;
    using DataAnnotations;
    using Extensions;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using global::NHibernate.Type;


    public class DatePropertyConvention : IPropertyConventionAcceptance, IPropertyConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria
                .Expect(inspector => inspector.Property.IsOfType<DateTime, DateTime?>())
                .Any(
                    x => x.Expect(inspector => inspector.Property.HasAttribute<DateAttribute>()),
                    x => x.Expect(inspector => inspector.Property.Name.EndsWith("Date")));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<DateType>();
        }
    }
}