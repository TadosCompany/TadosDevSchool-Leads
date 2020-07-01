namespace Leads.Domain.Clients.Objects.Entities
{
    using System;
    using Common;
    using Infrastructure.DataAnnotations;
    using Infrastructure.Domain.Entities.Base;


    public class ClientSource : Entity, IHasName, IDummyDeletable
    {
        [Obsolete("Only for reflection", true)]
        public ClientSource()
        {
        }

        public ClientSource(string name)
        {
            CreatedAtUtc = DateTime.UtcNow;
            Edit(name);
        }


        [Unique]
        public virtual string Name { get; protected set; }

        public virtual DateTime CreatedAtUtc { get; protected set; }

        public virtual DateTime? DeletedAtUtc { get; protected set; }

        public virtual bool IsDeleted => DeletedAtUtc.HasValue;


        protected internal virtual void Edit(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name.Trim();
        }

        public virtual void Delete()
        {
            DeletedAtUtc ??= DateTime.UtcNow;

            // TODO : exception?
        }

        protected internal virtual void Restore()
        {
            if (DeletedAtUtc != null)
                DeletedAtUtc = null;

            // TODO : exception?
        }
    }
}