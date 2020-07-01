namespace Leads.WebApi.Application.Infrastructure.Controllers
{
    using System;
    using Exceptions.Factories.Abstractions;
    using global::Infrastructure.Transactions.Behaviors;
    using Microsoft.AspNetCore.Mvc;
    using Requests.Handlers.Factories;


    public abstract class ApiRequestControllerBase : Controller, IApiRequestController
    {
        private readonly IApiRequestHandlerFactory _apiRequestHandlerFactory;
        private readonly IExpectCommit _expectCommit;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        protected ApiRequestControllerBase(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit,
            IApiExceptionFactory apiExceptionFactory)
        {
            _apiRequestHandlerFactory = apiRequestHandlerFactory ??
                                        throw new ArgumentNullException(nameof(apiRequestHandlerFactory));
            _expectCommit = expectCommit ?? throw new ArgumentNullException(nameof(expectCommit));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        IApiRequestHandlerFactory IApiRequestController.ApiRequestHandlerFactory => _apiRequestHandlerFactory;

        IExpectCommit IApiRequestController.ExpectCommit => _expectCommit;

        IApiExceptionFactory IApiRequestController.ApiExceptionFactory => _apiExceptionFactory;
    }
}