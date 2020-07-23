namespace Events.HandlerFactories.Abstractions
{
    using System.Collections.Generic;
    using Events.Abstractions;
    using Handlers.Abstractions;

    public interface IEventHandlerFactory<TEvent>
        where TEvent : IEvent
    {
        IEnumerable<IEventHandler<TEvent, TConcreteEvent>> CreateEventHandlersFor<TConcreteEvent>()
            where TConcreteEvent : TEvent;
    }
}
