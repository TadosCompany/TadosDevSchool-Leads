namespace Infrastructure.Domain.ValueObjects.Base
{
    using Abstractions;
    using Identification.Base;


    public abstract class ValueObjectWithId : HasIdBase, IValueObject
    {
        protected ValueObjectWithId()
        {
        }

        protected ValueObjectWithId(long id) : base(id)
        {
        }
    }
}