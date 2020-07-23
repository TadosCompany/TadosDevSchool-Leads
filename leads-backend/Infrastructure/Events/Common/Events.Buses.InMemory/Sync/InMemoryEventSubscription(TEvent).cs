namespace Events.Buses.InMemory.Sync
{
    using System;
    using Abstractions;
    using Events.Abstractions;

    internal class InMemoryEventSubscription<TEvent>
        where TEvent : IEvent
    {
        private InMemoryEventSubscription(Action<TEvent> action)
        {
            Token = new InMemoryEventSubscriptionToken();
            Action = action;
        }



        public IEventSubscriptionToken Token { get; protected set; }

        public Action<TEvent> Action { get; protected set; }



        public static InMemoryEventSubscription<TEvent> Create<TConcreteEvent>(Action<TConcreteEvent> action)
            where TConcreteEvent : class, TEvent
        {
            return new InMemoryEventSubscription<TEvent>(WeaklyTypedAction);



            void WeaklyTypedAction(TEvent @event)
            {
                if (@event is TConcreteEvent concreteEvent)
                {
                    action(concreteEvent);
                }
            }
        }
    }
}
