namespace Leads.WebApi.Application.Areas.Api.User.Requests.List
{
    using Filters;
    using FluentValidation;
    using Infrastructure.Requests;


    public class GetUsersListRequest : IApiRequest<GetUsersListRequestResult>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public AdminUserFilter Filter { get; set; }
    }


    public class GetUsersListRequestValidator : AbstractValidator<GetUsersListRequest>
    {
        public GetUsersListRequestValidator()
        {
            RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Count).GreaterThanOrEqualTo(0);
        }
    }
}