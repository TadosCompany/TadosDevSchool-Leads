namespace Infrastructure.Commands.Builders.Default
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Contexts.Abstractions;
    using Factories.Abstractions;


    public class AsyncCommandBuilder : IAsyncCommandBuilder
    {
        private readonly IAsyncCommandFactory _asyncCommandFactory;


        public AsyncCommandBuilder(IAsyncCommandFactory asyncCommandFactory)
        {
            _asyncCommandFactory = asyncCommandFactory ?? throw new ArgumentNullException(nameof(asyncCommandFactory));
        }


        public Task ExecuteAsync<TCommandContext>(
            TCommandContext commandContext,
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext
        {
            return _asyncCommandFactory.Create<TCommandContext>().ExecuteAsync(commandContext, cancellationToken);
        }
    }
}