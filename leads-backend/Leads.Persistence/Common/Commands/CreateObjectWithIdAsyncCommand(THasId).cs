namespace Leads.Persistence.Common.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure.Commands.Contexts.Common;
    using Infrastructure.Identification.Abstractions;
    using Infrastructure.Repositories.Abstractions;


    public class CreateObjectWithIdRepositoryAsyncCommand<THasId>
        : RepositoryAsyncCommandBase<THasId, CreateCommandContext<THasId>>
        where THasId : class, IHasId, new()
    {
        public CreateObjectWithIdRepositoryAsyncCommand(IAsyncRepository<THasId> repository) : base(repository)
        {
        }


        public override Task ExecuteAsync(
            CreateCommandContext<THasId> commandContext,
            CancellationToken cancellationToken = default)
        {
            return Repository.AddAsync(commandContext.ObjectWithId, cancellationToken);
        }
    }
}