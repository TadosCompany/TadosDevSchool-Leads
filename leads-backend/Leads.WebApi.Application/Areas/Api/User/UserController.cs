namespace Leads.WebApi.Application.Areas.Api.User
{
    using System.Threading.Tasks;
    using Authorization;
    using Dto;
    using global::Infrastructure.Transactions.Behaviors;
    using Infrastructure.Controllers;
    using Infrastructure.Controllers.Extensions;
    using Infrastructure.Requests.Handlers.Factories;
    using Infrastructure.Responses;
    using Infrastructure.Responses.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Requests.Add;
    using Requests.CurrentUser;
    using Requests.ResetPassword;


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
        [ProducesResponseType(typeof(CurrentUserRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Current([FromBody] CurrentUserRequest request)
        {
            return this.Process(request, (CurrentUserRequestResult result) => result).ToActionResult();
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(AddUserRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            return this.ProcessAsync(request, (AddUserRequestResult result) => result).ToActionResultAsync();
        }
        
        [HttpPost]
        [Route("resetPassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }
    }
}