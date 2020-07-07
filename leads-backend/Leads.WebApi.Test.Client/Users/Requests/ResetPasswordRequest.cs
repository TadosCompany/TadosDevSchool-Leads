namespace Leads.WebApi.Test.Client.Users.Requests
{
    public class ResetPasswordRequest
    {
        public ResetPasswordRequest(long id)
        {
            Id = id;
        }


        public long Id { get; }
    }
}