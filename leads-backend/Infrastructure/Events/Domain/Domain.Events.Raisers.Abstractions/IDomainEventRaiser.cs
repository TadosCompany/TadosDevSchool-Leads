namespace Domain.Events.Raisers.Abstractions
{
    using Events.Abstractions;
    using global::Events.Raisers.Abstractions;

    public interface IDomainEventRaiser : IEventRaiser<IDomainEvent>
    {
    }
}
