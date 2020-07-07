namespace Leads.WebApi.Test.Client.Users.Requests
{
    public class RestoreUserRequest
    {
        public RestoreUserRequest(long id)
        {
            Id = id;
        }


        public long Id { get; }
    }
}