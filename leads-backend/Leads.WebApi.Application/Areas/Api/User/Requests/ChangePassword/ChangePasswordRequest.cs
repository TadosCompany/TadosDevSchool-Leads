namespace Leads.WebApi.Application.Areas.Api.User.Requests.ChangePassword
{
    using FluentValidation;
    using Infrastructure.Requests;


    public class ChangePasswordRequest : IApiRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }


    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty();

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}