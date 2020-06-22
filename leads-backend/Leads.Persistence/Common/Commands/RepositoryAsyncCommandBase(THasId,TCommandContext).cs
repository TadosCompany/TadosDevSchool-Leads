namespace Leads.Persistence.Common.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Commands.Abstractions;
    using Infrastructure.Commands.Contexts.Abstractions;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Repositories.Abstractions;


    public abstract class RepositoryAsyncCommandBase<THasId, TCommandContext> : IAsyncCommand<TCommandContext>
        where THasId : class, IHasId, new()
        where TCommandContext : ICommandContext
    {
        protected RepositoryAsyncCommandBase(IAsyncRepository<THasId> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        protected IAsyncRepository<THasId> Repository { get; }


        public abstract Task ExecuteAsync(
            TCommandContext commandContext,
            CancellationToken cancellationToken = default);
    }
}