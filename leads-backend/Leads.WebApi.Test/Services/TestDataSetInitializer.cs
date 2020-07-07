namespace Leads.WebApi.Test.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Enums;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using Infrastructure.Transactions.Behaviors;
    using Tests.Common;

    public class TestDataSetInitializer
    {
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
        private static bool _initialized = false;

        private readonly IUserService _userService;
        private readonly IExpectCommit _expectCommit;


        public TestDataSetInitializer(IUserService userService, IExpectCommit expectCommit)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _expectCommit = expectCommit ?? throw new ArgumentNullException(nameof(expectCommit));
        }


        public async Task InitAsync()
        {
            try
            {
                await Semaphore.WaitAsync();

                if (_initialized)
                    return;

                await InitUsersAsync();

                _expectCommit.PerformCommit();

                _initialized = true;
            }
            finally
            {
                Semaphore.Release();
            }
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