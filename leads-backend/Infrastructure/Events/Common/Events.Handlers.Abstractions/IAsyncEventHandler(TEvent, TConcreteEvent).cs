namespace Events.Handlers.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventHandler<TEvent, in TConcreteEvent>
        where TEvent : IEvent
        where TConcreteEvent : TEvent
    {
        Task HandleAsync(TConcreteEvent @event, CancellationToken cancellationToken);
    }
}
