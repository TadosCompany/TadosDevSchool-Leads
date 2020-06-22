namespace Infrastructure.Commands.Contexts.Common.Extensions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Abstractions;
    using Identification.Abstractions;


    public static class CreateCommandContextExtensions
    {
        public static void Create<THasId>(
            this ICommandBuilder commandBuilder, 
            THasId objectWithId)
            where THasId : class, IHasId, new()
        {
            commandBuilder.Execute(new CreateCommandContext<THasId>(objectWithId));
        }


        public static Task CreateAsync<THasId>(
            this IAsyncCommandBuilder asyncCommandBuilder,
            THasId objectWithId,
            CancellationToken cancellationToken = default)
            where THasId : class, IHasId, new()
        {
            return asyncCommandBuilder.ExecuteAsync(new CreateCommandContext<THasId>(objectWithId), cancellationToken);
        }
    }
}