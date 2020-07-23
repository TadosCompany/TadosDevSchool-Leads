namespace Domain.Events.Dispatchers.Default
{
    using Abstractions;
    using Events.Abstractions;
    using global::Events.Dispatchers.Default;
    using HandlerBuilders.Abstractions;
    using HandlerFactories.Abstractions;

    public class DefaultAsyncDomainEventDispatcher : DefaultAsyncEventDispatcher<IDomainEvent, IAsyncDomainEventHandlerFactory, IAsyncDomainEventHandlerBuilder>, IAsyncDomainEventDispatcher
    {
        public DefaultAsyncDomainEventDispatcher(IAsyncDomainEventHandlerBuilder asyncEventHandlerBuilder) 
            : base(asyncEventHandlerBuilder)
        {
        }
    }
}
