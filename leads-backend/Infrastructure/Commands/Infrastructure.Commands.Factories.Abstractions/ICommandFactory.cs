namespace Infrastructure.Commands.Factories.Abstractions
{
    using Commands.Abstractions;
    using Contexts.Abstractions;


    public interface ICommandFactory
    {
        ICommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext;
    }
}