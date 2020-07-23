namespace Application.Events.Buses.InMemory
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Buses.InMemory.Async;

    public class InMemoryAsyncApplicationEventBus : InMemoryAsyncEventBus<IApplicationEvent>, IAsyncApplicationEventBus
    {
    }
}
