namespace Events.HandlerBuilders.Abstractions
{
    using Events.Abstractions;
    using HandlerFactories.Abstractions;

    public interface IEventHandlerBuilder<in TEvent, in TEventHandlerFactory>
        where TEvent : IEvent
        where TEventHandlerFactory : IEventHandlerFactory<TEvent>
    {
        void Handle<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent;
    }
}
