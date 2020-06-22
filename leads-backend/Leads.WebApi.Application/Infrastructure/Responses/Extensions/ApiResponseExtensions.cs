namespace Leads.WebApi.Application.Infrastructure.Responses.Extensions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;


    public static class ApiResponseExtensions
    {
        public static IActionResult ToActionResult(this ApiResponse apiResponse)
        {
            return !apiResponse.Success
                ? (IActionResult)new BadRequestObjectResult(apiResponse.Error)
                : new NoContentResult();
        }

        public static IActionResult ToActionResult<TResponseResult>(this ApiResponse<TResponseResult> apiResponse)
        {
            return !apiResponse.Success
                ? (IActionResult)new BadRequestObjectResult(apiResponse.Error)
                : new OkObjectResult(apiResponse.Data);
        }

        public static async Task<IActionResult> ToActionResultAsync(this Task<ApiResponse> apiResponseTask)
        {
            return (await apiResponseTask).ToActionResult();
        }

        public static async Task<IActionResult> ToActionResultAsync<TResponseResult>(
            this Task<ApiResponse<TResponseResult>> apiResponseTask)
        {
            return (await apiResponseTask).ToActionResult();
        }
    }
}