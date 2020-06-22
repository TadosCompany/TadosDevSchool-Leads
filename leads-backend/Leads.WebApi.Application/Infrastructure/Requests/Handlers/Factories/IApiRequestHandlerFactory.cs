namespace Leads.WebApi.Application.Infrastructure.Requests.Handlers.Factories
{
    using Results;


    public interface IApiRequestHandlerFactory
    {
        IApiRequestHandler<TRequest> CreateHandler<TRequest>()
            where TRequest : IApiRequest;

        IApiRequestHandler<TRequest, TResult> CreateHandler<TRequest, TResult>()
            where TRequest : IApiRequest<TResult>
            where TResult : IApiRequestResult;

        IAsyncApiRequestHandler<TRequest> CreateAsyncHandler<TRequest>()
            where TRequest : IApiRequest;

        IAsyncApiRequestHandler<TRequest, TResult> CreateAsyncHandler<TRequest, TResult>()
            where TRequest : IApiRequest<TResult>
            where TResult : IApiRequestResult;
    }
}