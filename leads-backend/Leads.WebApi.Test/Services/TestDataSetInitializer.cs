namespace Leads.WebApi.Test.Services
{
    using System;
    using System.Threading.Tasks;
    using Domain.Users.Enums;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using Infrastructure.Transactions.Behaviors;
    using Tests.Common;

    public class TestDataSetInitializer
    {
        private readonly IUserService _userService;
        private readonly IExpectCommit _expectCommit;


        public TestDataSetInitializer(IUserService userService, IExpectCommit expectCommit)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _expectCommit = expectCommit ?? throw new ArgumentNullException(nameof(expectCommit));
        }


        public async Task InitAsync()
        {
            await InitUsersAsync();
            
            _expectCommit.PerformCommit();
        }

        private async Task InitUsersAsync()
        {
            await _userService.CreateAsync(new User(
                SharedData.AdminCredentials.Email,
                SharedData.AdminCredentials.Password,
                UserRoles.Administrator));
            
            await _userService.CreateAsync(new User(
                SharedData.ManagerCredentials.Email,
                SharedData.ManagerCredentials.Password,
                UserRoles.Manager));
            
            await _userService.CreateAsync(new User(
                SharedData.MarketerCredentials.Email,
                SharedData.MarketerCredentials.Password,
                UserRoles.Marketer));
        }
    }
}