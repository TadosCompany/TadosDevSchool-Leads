namespace Domain.Events.Dispatchers.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Dispatchers.Default;
    using HandlerBuilders.Abstractions;
    using HandlerFactories.Abstractions;

    public class DefaultDomainEventDispatcher : DefaultEventDispatcher<IDomainEvent, IDomainEventHandlerFactory, IDomainEventHandlerBuilder>, IDomainEventDispatcher
    {
        public DefaultDomainEventDispatcher(IDomainEventHandlerBuilder eventHandlerBuilder) 
            : base(eventHandlerBuilder)
        {
        }
    }
}
