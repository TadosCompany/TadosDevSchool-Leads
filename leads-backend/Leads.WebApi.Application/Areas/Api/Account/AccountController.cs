namespace Leads.WebApi.Application.Areas.Api.Account
{
    using System.Threading.Tasks;
    using Authorization;
    using global::Infrastructure.Transactions.Behaviors;
    using Infrastructure.Controllers;
    using Infrastructure.Controllers.Extensions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers.Factories;
    using Infrastructure.Responses;
    using Infrastructure.Responses.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Requests.IsAuthorized;
    using Requests.SignIn;
    using Requests.SignOut;


    [Area(KnownAreas.Api)]
    [Authorize(Policy = Policies.User)]
    [Route("api/account")]
    public class AccountController : ApiRequestControllerBase
    {
        public AccountController(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit,
            IApiExceptionFactory apiExceptionFactory) : base(apiRequestHandlerFactory, expectCommit, apiExceptionFactory)
        {
        }


        [HttpPost]
        [Route("isAuthorized")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IsAuthorizedRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public IActionResult IsAuthorized([FromBody] IsAuthorizedRequest request)
        {
            return this.Process(request, (IsAuthorizedRequestResult result) => result).ToActionResult();
        }

        [HttpPost]
        [Route("signIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }

        [HttpPost]
        [Route("signOut")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> SignOut([FromBody] SignOutRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }
    }
}