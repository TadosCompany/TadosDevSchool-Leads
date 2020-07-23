namespace Events.Buses.InMemory
{
    using System;
    using System.Collections.Concurrent;
    using Events.Abstractions;

    internal class InMemoryEventsSubscriptions<TEvent> : ConcurrentDictionary<Type, InMemoryEventSubscriptions<TEvent>>
        where TEvent : IEvent
    {
    }
}
