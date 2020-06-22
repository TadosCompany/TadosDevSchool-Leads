namespace Infrastructure.Commands.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contexts.Abstractions;


    public interface IAsyncCommand<in TCommandContext>
        where TCommandContext : ICommandContext
    {
        Task ExecuteAsync(TCommandContext commandContext, CancellationToken cancellationToken = default);
    }
}