namespace Leads.WebApi.Application.Infrastructure.Requests.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Results;


    public interface IAsyncApiRequestHandler<in TRequest, TResult>
        where TRequest : IApiRequest<TResult>
        where TResult : IApiRequestResult
    {
        Task<TResult> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}