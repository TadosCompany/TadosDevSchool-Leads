namespace Leads.WebApi.Application.Areas.Api.User.Requests.Add
{
    using Domain.Users.Enums;
    using FluentValidation;
    using FluentValidation.Validators;
    using Infrastructure.Requests;


    public class AddUserRequest : IApiRequest<AddUserRequestResult>
    {
        public string Email { get; set; }

        public UserRoles Role { get; set; }
    }


    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}