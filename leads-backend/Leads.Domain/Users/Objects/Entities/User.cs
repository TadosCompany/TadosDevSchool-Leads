namespace Leads.Domain.Users.Objects.Entities
{
    using System;
    using Common;
    using Enums;
    using Infrastructure.DataAnnotations;
    using Infrastructure.Domain.Entities.Base;
    using ValueObjects;


    public class User : Entity, IDummyDeletable
    {
        [Obsolete("Only for reflection", true)]
        public User()
        {
        }

        public User(string email, string password, UserRoles role)
        {
            CreatedAtUtc = DateTime.UtcNow;
            Edit(email, role);
            SetPassword(password);
        }


        [Unique]
        public virtual string Email { get; protected set; }

        public virtual Password Password { get; protected set; }

        public virtual UserRoles Role { get; protected set; }

        public virtual DateTime CreatedAtUtc { get; protected set; }

        public virtual DateTime? DeletedAtUtc { get; protected set; }

        public virtual bool IsDeleted => DeletedAtUtc.HasValue;


        public virtual void SetPassword(string password)
        {
            Password = new Password(password);
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

        protected internal virtual void Edit(string email, UserRoles role)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));
            
            Email = email.Trim();
            Role = role;
        }
    }
}