namespace Leads.WebApi.Application.Infrastructure.Requests.Handlers
{
    public interface IApiRequestHandler<in TRequest> where TRequest : IApiRequest
    {
        void Execute(TRequest request);
    }
}