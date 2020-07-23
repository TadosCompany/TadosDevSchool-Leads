namespace Events.HandlerBuilders.Default
{
    using System;
    using Abstractions;
    using Events.Abstractions;
    using HandlerFactories.Abstractions;
    using Handlers.Abstractions;

    public class DefaultEventHandlerBuilder<TEvent, TEventHandlerFactory> : IEventHandlerBuilder<TEvent, TEventHandlerFactory>
        where TEvent : IEvent
        where TEventHandlerFactory : class, IEventHandlerFactory<TEvent>
    {
        private readonly TEventHandlerFactory _eventHandlerFactory;



        public DefaultEventHandlerBuilder(TEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory ?? throw new ArgumentNullException(nameof(eventHandlerFactory));
        }



        public void Handle<TConcreteEvent>(TConcreteEvent @event)
            where TConcreteEvent : TEvent
        {
            foreach (IEventHandler<TEvent, TConcreteEvent> eventHandler in _eventHandlerFactory.CreateEventHandlersFor<TConcreteEvent>())
            {
                eventHandler.Handle(@event);
            }
        }
    }
}
