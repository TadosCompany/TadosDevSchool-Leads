namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.List
{
    using Filters;
    using FluentValidation;
    using Infrastructure.Requests;


    public class GetClientSourcesListRequest : IApiRequest<GetClientSourcesListRequestResult>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public AdminClientSourceFilter Filter { get; set; }
    }

    public class GetClientSourcesListRequestValidator : AbstractValidator<GetClientSourcesListRequest>
    {
        public GetClientSourcesListRequestValidator()
        {
            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0);
        }
    }
}