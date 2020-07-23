namespace Domain.Events.HandlerBuilders.Abstractions
{
    using Events.Abstractions;
    using global::Events.HandlerBuilders.Abstractions;
    using HandlerFactories.Abstractions;

    public interface IDomainEventHandlerBuilder : IEventHandlerBuilder<IDomainEvent, IDomainEventHandlerFactory>
    {
    }
}
