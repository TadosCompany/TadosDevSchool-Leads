namespace Leads.WebApi.Application.Authorization.Requirements.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Users.Enums;
    using Domain.Users.Objects.Entities;
    using Leads.WebApi.Application.Infrastructure.Authorization.Providers;
    using Microsoft.AspNetCore.Authorization;


    public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IUserProvider<User> _userProvider;


        public AdminRequirementHandler(IUserProvider<User> userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }


        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            if (_userProvider.User != null && _userProvider.User.Role == UserRoles.Administrator)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}