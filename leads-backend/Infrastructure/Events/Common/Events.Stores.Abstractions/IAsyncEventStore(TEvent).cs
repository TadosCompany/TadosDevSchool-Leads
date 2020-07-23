namespace Events.Stores.Abstractions
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Events.Abstractions;

    public interface IAsyncEventStore<TEvent>
        where TEvent : IEvent
    {
        Task SaveAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken)
            where TConcreteEvent : TEvent;

        Task<IEnumerable<TEvent>> LoadAllAsync(CancellationToken cancellationToken);
    }
}
