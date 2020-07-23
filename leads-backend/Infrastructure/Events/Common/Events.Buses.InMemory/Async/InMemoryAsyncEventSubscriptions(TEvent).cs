namespace Events.Buses.InMemory.Async
{
    using System.Collections.Concurrent;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryAsyncEventSubscriptions<TEvent> : ConcurrentDictionary<IEventSubscriptionToken, InMemoryAsyncEventSubscription<TEvent>>
        where TEvent : IEvent
    {
    }
}
