namespace Leads.WebApi.Application.Infrastructure.Requests.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IAsyncApiRequestHandler<in TRequest> where TRequest : IApiRequest
    {
        Task ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}