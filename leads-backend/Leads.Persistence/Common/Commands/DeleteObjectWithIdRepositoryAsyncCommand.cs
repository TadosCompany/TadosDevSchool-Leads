namespace Leads.Persistence.Common.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Commands.Contexts.Common;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Repositories.Abstractions;


    public class DeleteObjectWithIdRepositoryAsyncCommand<THasId>
        : RepositoryAsyncCommandBase<THasId, DeleteCommandContext<THasId>>
        where THasId : class, IHasId, new()
    {
        public DeleteObjectWithIdRepositoryAsyncCommand(IAsyncRepository<THasId> repository) : base(repository)
        {
        }


        public override Task ExecuteAsync(
            DeleteCommandContext<THasId> commandContext,
            CancellationToken cancellationToken = default)
        {
            return Repository.DeleteAsync(commandContext.ObjectWithId, cancellationToken);
        }
    }
}