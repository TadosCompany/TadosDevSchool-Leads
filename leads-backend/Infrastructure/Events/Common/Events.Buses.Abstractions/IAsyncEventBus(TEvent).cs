namespace Events.Buses.Abstractions
{
    using System;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventBus<in TEvent>
        where TEvent : IEvent
    {
        Task<IEventSubscriptionToken> SubscribeAsync<TConcreteEvent>(Action<TConcreteEvent> action)
            where TConcreteEvent : class, TEvent;

        Task UnsubscribeAsync(IEventSubscriptionToken eventSubscriptionToken);

        Task PublishAsync<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
