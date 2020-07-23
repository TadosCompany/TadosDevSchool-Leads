namespace Events.Stores.Processors.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventStoreProcessor<TEvent, TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        Task ProcessAsync(CancellationToken cancellationToken = default);
    }
}
