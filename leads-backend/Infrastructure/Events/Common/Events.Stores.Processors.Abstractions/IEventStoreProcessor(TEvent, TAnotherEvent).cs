namespace Events.Stores.Processors.Abstractions
{
    using Events.Abstractions;

    public interface IEventStoreProcessor<TEvent, TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
    {
        void Process();
    }
}
