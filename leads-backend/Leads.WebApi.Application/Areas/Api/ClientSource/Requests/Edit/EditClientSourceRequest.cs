namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Edit
{
    using FluentValidation;
    using Infrastructure.Requests;


    public class EditClientSourceRequest : IApiRequest<EditClientSourceRequestResult>
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
    }


    public class EditClientSourceRequestValidator : AbstractValidator<EditClientSourceRequest>
    {
        public EditClientSourceRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}