namespace Leads.WebApi.Test.Client.Users.Requests
{
    public class DeleteUserRequest
    {
        public DeleteUserRequest(long id)
        {
            Id = id;
        }


        public long Id { get; }
    }
}