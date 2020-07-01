namespace Leads.WebApi.Application.Infrastructure.Controllers
{
    using Exceptions.Factories.Abstractions;
    using global::Infrastructure.Transactions.Behaviors;
    using Requests.Handlers.Factories;


    public interface IApiRequestController
    {
        IApiRequestHandlerFactory ApiRequestHandlerFactory { get; }

        IExpectCommit ExpectCommit { get; }
        
        IApiExceptionFactory ApiExceptionFactory { get; }
    }
}