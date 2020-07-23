namespace Events.Buses.InMemory
{
    using System;
    using Abstractions;

    internal class InMemoryEventSubscriptionToken : IEventSubscriptionToken
    {
        public Guid Guid { get; protected set; } = Guid.NewGuid();
    }
}
