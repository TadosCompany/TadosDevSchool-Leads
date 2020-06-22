namespace Infrastructure.Commands.Builders.Abstractions
{
    using Contexts.Abstractions;


    public interface ICommandBuilder
    {
        void Execute<TCommandContext>(TCommandContext commandContext) where TCommandContext : ICommandContext;
    }
}