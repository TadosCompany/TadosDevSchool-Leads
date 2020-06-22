namespace Leads.WebApi.Application.Authorization.Requirements.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Infrastructure.Authorization.Providers;
    using Microsoft.AspNetCore.Authorization;


    public class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        private readonly IUserProvider<User> _userProvider;


        public UserRequirementHandler(IUserProvider<User> userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }


        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UserRequirement requirement)
        {
            if (_userProvider.User != null)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}