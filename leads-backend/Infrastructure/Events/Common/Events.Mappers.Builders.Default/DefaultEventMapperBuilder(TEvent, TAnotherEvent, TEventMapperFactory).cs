namespace Events.Mappers.Builders.Default
{
    using Abstractions;
    using Events.Abstractions;
    using Factories.Abstractions;

    public class DefaultEventMapperBuilder<TEvent, TAnotherEvent, TEventMapperFactory> : IEventMapperBuilder<TEvent, TAnotherEvent>
        where TEvent : IEvent
        where TAnotherEvent : IEvent
        where TEventMapperFactory : IEventMapperFactory<TEvent, TAnotherEvent>
    {
        private readonly TEventMapperFactory _eventMapperFactory;



        public DefaultEventMapperBuilder(TEventMapperFactory eventMapperFactory)
        {
            _eventMapperFactory = eventMapperFactory;
        }



        public TAnotherEvent MapFrom<TConcreteEvent>(TConcreteEvent @event) 
            where TConcreteEvent : TEvent
            => _eventMapperFactory.CreateFor(@event).MapFrom(@event);
    }
}
