namespace Infrastructure.Identification.Base
{
    using System;
    using Abstractions;


    public abstract class HasIdBase : IHasId
    {
        protected HasIdBase()
        {
        }

        protected HasIdBase(long id)
        {
            SetId(id);
        }


        public virtual long Id { get; protected set; }


        public virtual void SetId(long id)
        {
            Id = id;
        }
        
        
        public override bool Equals(object anotherObject)
        {
            if (!(anotherObject is HasIdBase anotherHasIdBase))
                return false;

            return OrmCacheEquals(this, anotherHasIdBase) || DefaultEquals(this, anotherHasIdBase);
        }

        public override int GetHashCode()
        {
            // It's OK only for persisted HasIdBase.

            return Id.GetHashCode();
        }
        
        
        public static bool operator ==(HasIdBase hasIdBase1, HasIdBase hasIdBase2)
        {
            if (ReferenceEquals(hasIdBase1, null) && ReferenceEquals(hasIdBase2, null))
                return true;

            if (ReferenceEquals(hasIdBase1, null) || ReferenceEquals(hasIdBase2, null))
                return false;

            return hasIdBase1.Equals(hasIdBase2);
        }
        
        public static bool operator !=(HasIdBase hasIdBase1, HasIdBase hasIdBase2)
        {
            if (ReferenceEquals(hasIdBase1, null) && ReferenceEquals(hasIdBase2, null))
                return false;

            if (ReferenceEquals(hasIdBase1, null) || ReferenceEquals(hasIdBase2, null))
                return true;

            return !hasIdBase1.Equals(hasIdBase2);
        }

        private static bool OrmCacheEquals(object hasIdBase1, object hasIdBase2) =>
            ReferenceEquals(hasIdBase1, hasIdBase2);

        private static bool DefaultEquals(IHasId hasIdBase1, IHasId hasIdBase2)
        {
            if (hasIdBase1.Id.Equals(default) || hasIdBase2.Id.Equals(default))
                return false;

            if (!hasIdBase1.Id.Equals(hasIdBase2.Id))
                return false;

            Type entity1Type = hasIdBase1.GetType();
            Type entity2Type = hasIdBase2.GetType();

            return entity1Type == entity2Type ||
                   entity1Type.IsSubclassOf(entity2Type) ||
                   entity2Type.IsSubclassOf(entity1Type);
        }
    }
}