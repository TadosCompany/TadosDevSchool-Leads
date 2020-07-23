namespace Domain.Events.Dispatchers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Dispatchers.Abstractions;

    public interface IDomainEventDispatcher : IEventDispatcher<IDomainEvent>
    {
    }
}
