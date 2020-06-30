namespace Leads.Domain.Common
{
    using System;


    public interface IDummyDeletable
    {
        DateTime? DeletedAtUtc { get; }
    }
}