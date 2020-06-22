namespace Infrastructure.Commands.Contexts.Common.Extensions
{
    using System.Threading;
    using System.Threading.Tasks;
    using Builders.Abstractions;
    using Identification.Abstractions;


    public static class DeleteCommandContextExtensions
    {
        public static void Delete<THasId>(
            this ICommandBuilder commandBuilder,
            THasId objectWithId)
            where THasId : class, IHasId, new()
        {
            commandBuilder.Execute(new DeleteCommandContext<THasId>(objectWithId));
        }


        public static Task DeleteAsync<THasId>(
            this IAsyncCommandBuilder asyncCommandBuilder,
            THasId objectWithId,
            CancellationToken cancellationToken = default)
            where THasId : class, IHasId, new()
        {
            return asyncCommandBuilder.ExecuteAsync(new DeleteCommandContext<THasId>(objectWithId), cancellationToken);
        }
    }
}