namespace Leads.WebApi.Application.Areas.Api.User.Requests.Edit
{
    using Domain.Users.Enums;
    using FluentValidation;
    using FluentValidation.Validators;
    using Infrastructure.Requests;


    public class EditUserRequest : IApiRequest<EditUserRequestResult>
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public UserRoles Role { get; set; }
    }


    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}