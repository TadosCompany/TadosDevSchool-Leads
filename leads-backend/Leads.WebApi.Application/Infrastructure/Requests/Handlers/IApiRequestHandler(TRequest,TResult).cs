namespace Leads.WebApi.Application.Infrastructure.Requests.Handlers
{
    using Results;


    public interface IApiRequestHandler<in TRequest, out TResult>
        where TRequest : IApiRequest<TResult>
        where TResult : IApiRequestResult
    {
        TResult Execute(TRequest request);
    }
}