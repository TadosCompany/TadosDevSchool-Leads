namespace Leads.WebApi.Test.Tests.User
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Client.Users.Data;
    using Common;
    using Xunit;


    public class UserTests : ApiTestBase
    {
        public UserTests(WebApiApplicationFactory webApiApplicationFactory) : base(webApiApplicationFactory)
        {
        }


        [Fact]
        public async Task UnauthorizedCurrentUserTest()
        {
            using var api = CreateApi();

            using (var currentUserResult = await api.User.CurrentUserAsync())
            {
                Assert.Equal(HttpStatusCode.Unauthorized, currentUserResult.HttpResponse.StatusCode);
            }
        }

        // TODO : 1. should we check Unauthorized for Admin actions?
        // TODO : 2. should we check validation stuff?

        [Fact]
        public async Task AddUserTest()
        {
            using var api = CreateApi();

            (await api.Account.SignInAsync(SharedData.AdminCredentials.Email, SharedData.AdminCredentials.Password))
                .Dispose();

            string email = $"{Guid.NewGuid()}@domain.com";

            User user;

            using (var addUserResult = await api.User.AddAsync(email, UserRoles.Manager))
            {
                Assert.Equal(HttpStatusCode.OK, addUserResult.HttpResponse.StatusCode);
                user = await addUserResult.GetPropertyValueAsync(x => x.User);

                Assert.Equal(email, user.Email);
                Assert.Equal(UserRoles.Manager, user.Role);
            }

            using (var getUsersResult = await api.User.ListAsync(0, 1, new AdminUserFilter(null, false, email)))
            {
                Assert.Equal(HttpStatusCode.OK, getUsersResult.HttpResponse.StatusCode);
                var resultsList = await getUsersResult.GetPropertyValueAsync(x => x.PaginatedList);

                Assert.Equal(1, resultsList.TotalCount);
                Assert.Single(resultsList.Items);
                Assert.Equal(email, resultsList.Items[0].Email);
                Assert.Equal(UserRoles.Manager, resultsList.Items[0].Role);
                Assert.Equal(user.Id, resultsList.Items[0].Id);
            }
        }
    }
}