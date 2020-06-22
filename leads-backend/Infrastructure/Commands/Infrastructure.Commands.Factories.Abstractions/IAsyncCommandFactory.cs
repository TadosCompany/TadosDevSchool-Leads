namespace Infrastructure.Commands.Factories.Abstractions
{
    using Commands.Abstractions;
    using Contexts.Abstractions;


    public interface IAsyncCommandFactory
    {
        IAsyncCommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext;
    }
}