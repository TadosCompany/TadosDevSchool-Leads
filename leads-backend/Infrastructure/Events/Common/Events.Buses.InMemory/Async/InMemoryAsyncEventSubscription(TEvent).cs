namespace Events.Buses.InMemory.Async
{
    using System;
    using System.Threading.Tasks;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryAsyncEventSubscription<TEvent>
        where TEvent : IEvent
    {
        private InMemoryAsyncEventSubscription(Func<TEvent, Task> action)
        {
            Token = new InMemoryEventSubscriptionToken();
            Action = action;
        }



        public IEventSubscriptionToken Token { get; protected set; }

        public Func<TEvent, Task> Action { get; protected set; }



        public static InMemoryAsyncEventSubscription<TEvent> Create<TConcreteEvent>(Func<TConcreteEvent, Task> action)
            where TConcreteEvent : class, TEvent
        {
            return new InMemoryAsyncEventSubscription<TEvent>(WeaklyTypedAction);



            Task WeaklyTypedAction(TEvent @event)
            {
                if (@event is TConcreteEvent concreteEvent)
                {
                    return action(concreteEvent);
                }

                return Task.CompletedTask;
            }
        }
    }
}
