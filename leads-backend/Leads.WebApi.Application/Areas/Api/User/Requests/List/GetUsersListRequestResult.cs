namespace Leads.WebApi.Application.Areas.Api.User.Requests.List
{
    using System;
    using Dto;
    using Infrastructure.Pagination;
    using Infrastructure.Requests.Results;


    public class GetUsersListRequestResult : IApiRequestResult
    {
        public GetUsersListRequestResult(PaginatedList<UserDto> paginatedList)
        {
            PaginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
        }


        public PaginatedList<UserDto> PaginatedList { get; }
    }
}