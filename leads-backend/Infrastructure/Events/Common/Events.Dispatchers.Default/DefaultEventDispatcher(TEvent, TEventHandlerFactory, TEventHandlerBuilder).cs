namespace Events.Dispatchers.Default
{
    using System;
    using Abstractions;
    using Events.Abstractions;
    using HandlerBuilders.Abstractions;
    using HandlerFactories.Abstractions;

    public class DefaultEventDispatcher<TEvent, TEventHandlerFactory, TEventHandlerBuilder> : IEventDispatcher<TEvent>
        where TEvent : IEvent
        where TEventHandlerFactory : IEventHandlerFactory<TEvent>
        where TEventHandlerBuilder : class, IEventHandlerBuilder<TEvent, TEventHandlerFactory>
    {
        private readonly IEventHandlerBuilder<TEvent, TEventHandlerFactory> _eventHandlerBuilder;



        public DefaultEventDispatcher(TEventHandlerBuilder eventHandlerBuilder)
        {
            _eventHandlerBuilder = eventHandlerBuilder ?? throw new ArgumentNullException(nameof(eventHandlerBuilder));
        }



        public void Dispatch<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
        {
            _eventHandlerBuilder.Handle(@event);
        }
    }
}
