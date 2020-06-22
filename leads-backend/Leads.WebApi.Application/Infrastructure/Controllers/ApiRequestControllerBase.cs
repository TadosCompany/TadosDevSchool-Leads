namespace Leads.WebApi.Application.Infrastructure.Controllers
{
    using System;
    using global::Infrastructure.Transactions.Behaviors;
    using Microsoft.AspNetCore.Mvc;
    using Requests.Handlers.Factories;


    public abstract class ApiRequestControllerBase : Controller, IApiRequestController
    {
        private readonly IApiRequestHandlerFactory _apiRequestHandlerFactory;
        private readonly IExpectCommit _expectCommit;


        protected ApiRequestControllerBase(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit)
        {
            _apiRequestHandlerFactory = apiRequestHandlerFactory ??
                                        throw new ArgumentNullException(nameof(apiRequestHandlerFactory));
            _expectCommit = expectCommit ?? throw new ArgumentNullException(nameof(expectCommit));
        }


        IApiRequestHandlerFactory IApiRequestController.ApiRequestHandlerFactory => _apiRequestHandlerFactory;

        IExpectCommit IApiRequestController.ExpectCommit => _expectCommit;
    }
}