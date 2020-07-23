namespace Events.HandlerBuilders.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;
    using HandlerFactories.Abstractions;

    public interface IAsyncEventHandlerBuilder<in TEvent, in TAsyncEventHandlerFactory>
        where TEvent : IEvent
        where TAsyncEventHandlerFactory : IAsyncEventHandlerFactory<TEvent>
    {
        Task HandleAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken)
            where TConcreteEvent : TEvent;
    }
}
