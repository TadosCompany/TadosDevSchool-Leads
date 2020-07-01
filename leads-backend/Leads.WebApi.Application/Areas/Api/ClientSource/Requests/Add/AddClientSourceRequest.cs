namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Add
{
    using FluentValidation;
    using Infrastructure.Requests;


    public class AddClientSourceRequest : IApiRequest<AddClientSourceRequestResult>
    {
        public string Name { get; set; }
    }


    public class AddClientSourceRequestValidator : AbstractValidator<AddClientSourceRequest>
    {
        public AddClientSourceRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}