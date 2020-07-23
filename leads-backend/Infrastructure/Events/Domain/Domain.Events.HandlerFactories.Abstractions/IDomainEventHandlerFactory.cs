namespace Domain.Events.HandlerFactories.Abstractions
{
    using Events.Abstractions;
    using global::Events.HandlerFactories.Abstractions;

    public interface IDomainEventHandlerFactory : IEventHandlerFactory<IDomainEvent>
    {
    }
}
