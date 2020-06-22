namespace Leads.WebApi.Application.Infrastructure.Requests
{
    using Results;


    public interface IApiRequest<TResult> where TResult : IApiRequestResult
    {
    }
}