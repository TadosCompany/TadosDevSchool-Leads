namespace Application.Events.Buses.Abstractions
{
    using Events.Abstractions;
    using global::Events.Buses.Abstractions;

    public interface IAsyncApplicationEventBus : IAsyncEventBus<IApplicationEvent>
    {
    }
}
