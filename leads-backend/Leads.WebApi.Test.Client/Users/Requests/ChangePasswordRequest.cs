namespace Leads.WebApi.Test.Client.Users.Requests
{
    public class ChangePasswordRequest
    {
        public ChangePasswordRequest(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }


        public string OldPassword { get; }

        public string NewPassword { get; }
    }
}