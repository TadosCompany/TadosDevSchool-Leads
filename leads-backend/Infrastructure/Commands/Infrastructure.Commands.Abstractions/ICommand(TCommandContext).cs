namespace Infrastructure.Commands.Abstractions
{
    using Contexts.Abstractions;
    

    public interface ICommand<in TCommandContext>
        where TCommandContext : ICommandContext
    {
        void Execute(TCommandContext commandContext);
    }
}