namespace Leads.WebApi.Application.Areas.Api.User
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
    using Requests.Add;
    using Requests.ChangePassword;
    using Requests.CurrentUser;
    using Requests.Delete;
    using Requests.Edit;
    using Requests.List;
    using Requests.ResetPassword;
    using Requests.Restore;


    [Area(KnownAreas.Api)]
    [Authorize(Policy = Policies.User)]
    [Route("api/user")]
    public class UserController : ApiRequestControllerBase
    {
        public UserController(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit,
            IApiExceptionFactory apiExceptionFactory) : base(apiRequestHandlerFactory, expectCommit, apiExceptionFactory)
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

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(typeof(EditUserRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Add([FromBody] EditUserRequest request)
        {
            return this.ProcessAsync(request, (EditUserRequestResult result) => result).ToActionResultAsync();
        }

        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Delete([FromBody] DeleteUserRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }

        [HttpPost]
        [Route("restore")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Restore([FromBody] RestoreUserRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }

        [HttpPost]
        [Route("changePassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return this.Process(request).ToActionResult();
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(GetUsersListRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> List([FromBody] GetUsersListRequest request)
        {
            return this.ProcessAsync(request, (GetUsersListRequestResult result) => result).ToActionResultAsync();
        }
    }
}