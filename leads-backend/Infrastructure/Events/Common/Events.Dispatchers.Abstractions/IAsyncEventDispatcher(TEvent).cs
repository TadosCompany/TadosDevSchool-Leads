namespace Events.Dispatchers.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventDispatcher<in TEvent>
        where TEvent : IEvent
    {
        Task DispatchAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken)
            where TConcreteEvent : TEvent;
    }
}
