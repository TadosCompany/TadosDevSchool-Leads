namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.List
{
    using Dto;
    using Infrastructure.Pagination;
    using Infrastructure.Requests.Results;


    public class GetClientSourcesListRequestResult : IApiRequestResult
    {
        public GetClientSourcesListRequestResult(PaginatedList<ClientSourceDto> paginatedList)
        {
            PaginatedList = paginatedList;
        }


        public PaginatedList<ClientSourceDto> PaginatedList { get; }
    }
}