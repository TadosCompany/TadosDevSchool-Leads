namespace Events.Dispatchers.Default
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Events.Abstractions;
    using HandlerFactories.Abstractions;
    using HandlerBuilders.Abstractions;

    public class DefaultAsyncEventDispatcher<TEvent, TAsyncEventHandlerFactory, TAsyncEventHandlerBuilder> : IAsyncEventDispatcher<TEvent>
        where TEvent : IEvent
        where TAsyncEventHandlerFactory : IAsyncEventHandlerFactory<TEvent>
        where TAsyncEventHandlerBuilder : class, IAsyncEventHandlerBuilder<TEvent, TAsyncEventHandlerFactory>
    {
        private readonly IAsyncEventHandlerBuilder<TEvent, TAsyncEventHandlerFactory> _asyncEventHandlerBuilder;



        public DefaultAsyncEventDispatcher(TAsyncEventHandlerBuilder asyncEventHandlerBuilder)
        {
            _asyncEventHandlerBuilder = asyncEventHandlerBuilder ?? throw new ArgumentNullException(nameof(asyncEventHandlerBuilder));
        }



        public Task DispatchAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken = default) 
            where TConcreteEvent : TEvent
        {
            return _asyncEventHandlerBuilder.HandleAsync(@event, cancellationToken);
        }
    }
}
