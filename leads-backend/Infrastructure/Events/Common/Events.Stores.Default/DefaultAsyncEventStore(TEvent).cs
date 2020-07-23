namespace Events.Stores.Default
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Events.Abstractions;

    public class DefaultAsyncEventStore<TEvent> : IAsyncEventStore<TEvent>
        where TEvent : IEvent
    {
        private readonly ISet<TEvent> _events = new HashSet<TEvent>();



        public Task SaveAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken = default) 
            where TConcreteEvent : TEvent
        {
            _events.Add(@event);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<TEvent>> LoadAllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEvent> events = _events.AsEnumerable();

            return Task.FromResult(events);
        }
    }
}
