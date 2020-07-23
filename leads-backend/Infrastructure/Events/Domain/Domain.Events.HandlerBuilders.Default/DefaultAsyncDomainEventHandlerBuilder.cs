namespace Domain.Events.HandlerBuilders.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.HandlerBuilders.Default;
    using HandlerFactories.Abstractions;

    public class DefaultAsyncDomainEventHandlerBuilder : DefaultAsyncEventHandlerBuilder<IDomainEvent, IAsyncDomainEventHandlerFactory>, IAsyncDomainEventHandlerBuilder
    {
        public DefaultAsyncDomainEventHandlerBuilder(IAsyncDomainEventHandlerFactory asyncEventHandlerFactory)
            : base(asyncEventHandlerFactory)
        {
        }
    }
}
