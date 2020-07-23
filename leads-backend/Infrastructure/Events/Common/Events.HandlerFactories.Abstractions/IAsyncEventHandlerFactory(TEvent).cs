namespace Events.HandlerFactories.Abstractions
{
    using System.Collections.Generic;
    using Events.Abstractions;
    using Handlers.Abstractions;

    public interface IAsyncEventHandlerFactory<TEvent>
        where TEvent : IEvent
    {
        IEnumerable<IAsyncEventHandler<TEvent, TConcreteEvent>> CreateAsyncEventHandlersFor<TConcreteEvent>()
            where TConcreteEvent : TEvent;
    }
}
