namespace Domain.Events.HandlerFactories.Abstractions
{
    using Events.Abstractions;
    using global::Events.HandlerFactories.Abstractions;

    public interface IAsyncDomainEventHandlerFactory : IAsyncEventHandlerFactory<IDomainEvent>
    {
    }
}
