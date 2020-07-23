namespace Application.Events.Buses.InMemory
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Buses.InMemory;
    using global::Events.Buses.InMemory.Sync;

    public class InMemoryApplicationEventBus : InMemoryEventBus<IApplicationEvent>, IApplicationEventBus
    {
    }
}
