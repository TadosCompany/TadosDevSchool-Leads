namespace Leads.WebApi.Application.Areas.Api.Account.Requests.SignIn
{
    using FluentValidation;
    using FluentValidation.Validators;
    using Infrastructure.Requests;


    public class SignInRequest : IApiRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }


    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}