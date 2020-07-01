#if DEBUG
namespace Leads.WebApi.Application.Areas.Service.User
{
    using System.Threading.Tasks;
    using global::Infrastructure.Transactions.Behaviors;
    using Infrastructure.Controllers;
    using Infrastructure.Controllers.Extensions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers.Factories;
    using Infrastructure.Responses;
    using Infrastructure.Responses.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Requests.CreateFirstAdmin;


    [Area("Service")]
    [Route("service/user")]
    public class UserController : ApiRequestControllerBase
    {
        public UserController(
            IApiRequestHandlerFactory apiRequestHandlerFactory,
            IExpectCommit expectCommit,
            IApiExceptionFactory apiExceptionFactory) : base(apiRequestHandlerFactory, expectCommit, apiExceptionFactory)
        {
        }


        [HttpPost]
        [Route("createFirstAdmin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateFirstAdmin([FromBody] CreateFirstAdminRequest request)
        {
            return this.ProcessAsync(request).ToActionResultAsync();
        }
    }
}
#endif