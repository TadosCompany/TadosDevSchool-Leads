namespace Infrastructure.Domain.Entities.Base
{
    using Abstractions;
    using Identification.Base;


    public abstract class Entity : HasIdBase, IEntity
    {
        protected Entity()
        {
        }

        protected Entity(long id) : base(id)
        {
        }
    }
}