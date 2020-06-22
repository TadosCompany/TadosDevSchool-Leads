namespace Leads.WebApi.Application.Areas.Api.User
{
    using Authorization;
    using Dto;
    using global::Infrastructure.Transactions.Behaviors;
    using Infrastructure.Controllers;
    using Infrastructure.Controllers.Extensions;
    using Infrastructure.Requests.Handlers.Factories;
    using Infrastructure.Responses.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Requests.CurrentUser;


    [Area(KnownAreas.Api)]
    [Authorize(Policy = Policies.User)]
    [Route("api/user")]
    public class UserController : ApiRequestControllerBase
    {
        public UserController(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit) : base(apiRequestHandlerFactory, expectCommit)
        {
        }


        [HttpPost]
        [Route("current")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Current([FromBody] CurrentUserRequest request)
        {
            return this.Process(request, (CurrentUserRequestResult result) => result).ToActionResult();
        }
    }
}