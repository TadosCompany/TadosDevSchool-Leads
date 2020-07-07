namespace Leads.WebApi.Test.Client.Users.Requests
{
    using Data;


    public class GetUsersListRequest
    {
        public GetUsersListRequest(int offset, int count, AdminUserFilter filter)
        {
            Offset = offset;
            Count = count;
            Filter = filter;
        }


        public int Offset { get; }

        public int Count { get; }

        public AdminUserFilter Filter { get; }
    }
}