namespace Leads.WebApi.Test.Client.Users
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Common;
    using Common.Results;
    using Data;
    using Requests;
    using Results;


    public class UserApi : ApiClientBase
    {
        public UserApi(HttpClient client) : base(client)
        {
        }


        public Task<ApiResult<CurrentUserRequestResult>> CurrentUserAsync()
        {
            return MakeRequestAsync<CurrentUserRequest, CurrentUserRequestResult>(
                "api/user/current",
                new CurrentUserRequest());
        }

        public Task<ApiResult<AddUserRequestResult>> AddAsync(string email, UserRoles role)
        {
            return MakeRequestAsync<AddUserRequest, AddUserRequestResult>(
                "api/user/add",
                new AddUserRequest(email, role));
        }

        public Task<ApiResult<EditUserRequestResult>> EditAsync(long id, string email, UserRoles role)
        {
            return MakeRequestAsync<EditUserRequest, EditUserRequestResult>(
                "api/user/edit",
                new EditUserRequest(id, email, role));
        }

        public Task<ApiResult> DeleteAsync(long id)
        {
            return MakeRequestAsync(
                "api/user/delete",
                new DeleteUserRequest(id));
        }

        public Task<ApiResult> RestoreAsync(long id)
        {
            return MakeRequestAsync(
                "api/user/restore",
                new RestoreUserRequest(id));
        }

        public Task<ApiResult> ResetPasswordAsync(long id)
        {
            return MakeRequestAsync(
                "api/user/resetPassword",
                new ResetPasswordRequest(id));
        }

        public Task<ApiResult> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            return MakeRequestAsync(
                "api/user/changePassword",
                new ChangePasswordRequest(oldPassword, newPassword));
        }

        public Task<ApiResult<GetUsersListRequestResult>> ListAsync(int offset, int count, AdminUserFilter filter)
        {
            return MakeRequestAsync<GetUsersListRequest, GetUsersListRequestResult>(
                "api/user/list",
                new GetUsersListRequest(offset, count, filter));
        }
    }
}