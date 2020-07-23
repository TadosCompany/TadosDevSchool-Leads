namespace Events.Buses.InMemory.Async
{
    using System;
    using System.Collections.Concurrent;
    using Events.Abstractions;

    internal class InMemoryAsyncEventsSubscriptions<TEvent> : ConcurrentDictionary<Type, InMemoryAsyncEventSubscriptions<TEvent>>
        where TEvent : IEvent
    {
    }
}
