namespace Leads.WebApi.Application.Areas.Service.User.Requests.CreateFirstAdmin
{
    using FluentValidation;
    using FluentValidation.Validators;
    using Infrastructure.Requests;

    public class CreateFirstAdminRequest : IApiRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }


    public class CreateFirstAdminRequestValidator : AbstractValidator<CreateFirstAdminRequest>
    {
        public CreateFirstAdminRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}