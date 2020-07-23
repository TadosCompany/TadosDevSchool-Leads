namespace Application.Events.Buses.InMemory
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Buses.InMemory;

    public class AsyncInMemoryApplicationEventBus : AsyncInMemoryEventBus<IApplicationEvent>, IAsyncApplicationEventBus
    {
    }
}
