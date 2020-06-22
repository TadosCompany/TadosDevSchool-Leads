namespace Infrastructure.Commands.Builders.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contexts.Abstractions;


    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<TCommandContext>(
            TCommandContext commandContext,
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext;
    }
}