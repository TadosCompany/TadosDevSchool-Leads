namespace Leads.WebApi.Test.Tests.Account
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Application;
    using Common;
    using Domain.Users.Enums;
    using Xunit;


    public class AccountTests : ApiTestBase
    {
        public AccountTests(WebApiApplicationFactory webApiApplicationFactory) : base(webApiApplicationFactory)
        {
        }


        [Fact]
        public async Task InitiallyNotAuthorizedTest()
        {
            using var api = CreateApi();

            using var isAuthorizedApiResult = await api.Account.IsAuthorizedAsync();
            Assert.Equal(HttpStatusCode.OK, isAuthorizedApiResult.HttpResponse.StatusCode);
            Assert.False(await isAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
        }

        [Theory]
        [MemberData(nameof(GetAuthenticateTestData))]
        public async Task AuthenticateTest((string Email, string Password) credentials, UserRoles expectedRole)
        {
            using var api = CreateApi();

            var (email, password) = credentials;

            using (var isNotAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isNotAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.False(await isNotAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }

            using (var signInApiResult = await api.Account.SignInAsync(email, password))
            {
                Assert.Equal(HttpStatusCode.NoContent, signInApiResult.HttpResponse.StatusCode);
            }

            using (var isAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.True(await isAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }

            using (var currentUserApiResult = await api.User.CurrentUserAsync())
            {
                Assert.Equal(HttpStatusCode.OK, currentUserApiResult.HttpResponse.StatusCode);
                Assert.Equal(expectedRole, await currentUserApiResult.GetPropertyValueAsync(x => x.User.Role));
            }
        }

        [Fact]
        public async Task WrongUserWrongPasswordCredentialsTest()
        {
            using var api = CreateApi();

            using (var apiResult = await api.Account.SignInAsync("wrong_user@wrong_domain.com", "wrond_password"))
            {
                Assert.Equal(HttpStatusCode.BadRequest, apiResult.HttpResponse.StatusCode);
                Assert.Equal(ErrorCodes.EmailOrPasswordIsIncorrect, (await apiResult.GetErrorAsync()).Code);
            }
        }

        [Fact]
        public async Task CorrectUserWrongPasswordCredentialsTest()
        {
            using var api = CreateApi();

            using (var apiResult = await api.Account.SignInAsync(SharedData.AdminCredentials.Email, "wrond_password"))
            {
                Assert.Equal(HttpStatusCode.BadRequest, apiResult.HttpResponse.StatusCode);
                Assert.Equal(ErrorCodes.EmailOrPasswordIsIncorrect, (await apiResult.GetErrorAsync()).Code);
            }
        }

        [Fact]
        public async Task SignOutTest()
        {
            using var api = CreateApi();

            using (var isNotAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isNotAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.False(await isNotAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }

            using (var signInApiResult = await api.Account.SignInAsync(SharedData.AdminCredentials.Email,
                SharedData.AdminCredentials.Password))
            {
                Assert.Equal(HttpStatusCode.NoContent, signInApiResult.HttpResponse.StatusCode);
            }

            using (var isAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.True(await isAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }

            using (var signOutApiResult = await api.Account.SignOutAsync())
            {
                Assert.Equal(HttpStatusCode.NoContent, signOutApiResult.HttpResponse.StatusCode);
            }

            using (var isNotAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isNotAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.False(await isNotAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }
        }

        [Fact]
        public async Task UnauthorizedSignOutTest()
        {
            using var api = CreateApi();

            using (var isNotAuthorizedApiResult = await api.Account.IsAuthorizedAsync())
            {
                Assert.Equal(HttpStatusCode.OK, isNotAuthorizedApiResult.HttpResponse.StatusCode);
                Assert.False(await isNotAuthorizedApiResult.GetPropertyValueAsync(x => x.IsAuthorized));
            }
            
            using (var signOutApiResult = await api.Account.SignOutAsync())
            {
                Assert.Equal(HttpStatusCode.Unauthorized, signOutApiResult.HttpResponse.StatusCode);
            }
        }

        public static IEnumerable<object[]> GetAuthenticateTestData()
        {
            yield return new object[] {SharedData.AdminCredentials, UserRoles.Administrator,};
            yield return new object[] {SharedData.ManagerCredentials, UserRoles.Manager,};
            yield return new object[] {SharedData.MarketerCredentials, UserRoles.Marketer,};
        }
    }
}