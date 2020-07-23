namespace Domain.Events.HandlerBuilders.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.HandlerBuilders.Default;
    using HandlerFactories.Abstractions;

    public class DefaultDomainEventHandlerBuilder : DefaultEventHandlerBuilder<IDomainEvent, IDomainEventHandlerFactory>, IDomainEventHandlerBuilder
    {
        public DefaultDomainEventHandlerBuilder(IDomainEventHandlerFactory eventHandlerFactory)
            : base(eventHandlerFactory)
        {
        }
    }
}
