namespace Leads.WebApi.Application.Areas.Api.ClientSource
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
    using Requests.Delete;
    using Requests.Edit;
    using Requests.List;
    using Requests.Restore;


    [Area(KnownAreas.Api)]
    [Authorize(Policy = Policies.User)]
    [Route("api/clientSource")]
    public class ClientSourceController : ApiRequestControllerBase
    {
        public ClientSourceController(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit,
            IApiExceptionFactory apiExceptionFactory) : base(apiRequestHandlerFactory, expectCommit, apiExceptionFactory)
        {
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(AddClientSourceRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Add([FromBody] AddClientSourceRequest request)
        {
            return this.ProcessAsync(request, (AddClientSourceRequestResult result) => result).ToActionResultAsync();
        }

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(typeof(AddClientSourceRequestResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Edit([FromBody] EditClientSourceRequest request)
        {
            return this.ProcessAsync(request, (EditClientSourceRequestResult result) => result).ToActionResultAsync();
        }

        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Delete([FromBody] DeleteClientSourceRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }

        [HttpPost]
        [Route("restore")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> Restore([FromBody] RestoreClientSourceRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }

        [HttpPost]
        [Route("list")]
        [ProducesResponseType(typeof(GetClientSourcesListRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.Admin)]
        public Task<IActionResult> List([FromBody] GetClientSourcesListRequest request)
        {
            return this
                .ProcessAsync(request, (GetClientSourcesListRequestResult result) => result)
                .ToActionResultAsync();
        }
    }
}