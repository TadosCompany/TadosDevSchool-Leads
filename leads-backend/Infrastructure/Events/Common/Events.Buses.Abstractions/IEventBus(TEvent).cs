namespace Events.Buses.Abstractions
{
    using System;
    using Events.Abstractions;

    public interface IEventBus<in TEvent>
        where TEvent : IEvent
    {
        IEventSubscriptionToken Subscribe<TConcreteEvent>(Action<TConcreteEvent> action)
            where TConcreteEvent : class, TEvent;

        void Unsubscribe(IEventSubscriptionToken eventSubscriptionToken);

        void Publish<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
