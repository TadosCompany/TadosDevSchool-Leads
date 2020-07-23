namespace Events.HandlerBuilders.Default
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Events.Abstractions;
    using HandlerFactories.Abstractions;
    using Handlers.Abstractions;

    public class DefaultAsyncEventHandlerBuilder<TEvent, TAsyncEventHandlerFactory> : IAsyncEventHandlerBuilder<TEvent, TAsyncEventHandlerFactory>
        where TEvent : IEvent
        where TAsyncEventHandlerFactory : class, IAsyncEventHandlerFactory<TEvent>
    {
        private readonly TAsyncEventHandlerFactory _asyncEventHandlerFactory;



        public DefaultAsyncEventHandlerBuilder(TAsyncEventHandlerFactory asyncEventHandlerFactory)
        {
            _asyncEventHandlerFactory = asyncEventHandlerFactory ?? throw new ArgumentNullException(nameof(asyncEventHandlerFactory));
        }



        public async Task HandleAsync<TConcreteEvent>(TConcreteEvent @event, CancellationToken cancellationToken = default)
            where TConcreteEvent : TEvent
        {
            foreach (IAsyncEventHandler<TEvent, TConcreteEvent> asyncEventHandler in _asyncEventHandlerFactory.CreateAsyncEventHandlersFor<TConcreteEvent>())
            {
                await asyncEventHandler.HandleAsync(@event, cancellationToken);
            }
        }
    }
}
