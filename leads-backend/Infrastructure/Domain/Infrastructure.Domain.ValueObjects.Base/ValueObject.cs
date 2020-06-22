namespace Infrastructure.Domain.ValueObjects.Base
{
    using Abstractions;


    public abstract class ValueObject : IValueObject
    {
        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}