namespace Events.Raisers.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventRaiser<in TEvent>
        where TEvent : IEvent
    {
        Task RaiseAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken = default)
            where TConcreteEvent : TEvent;
    }
}
