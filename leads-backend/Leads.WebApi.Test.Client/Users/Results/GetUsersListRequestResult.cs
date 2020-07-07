namespace Leads.WebApi.Test.Client.Users.Results
{
    using Common.Data;
    using Data;


    public class GetUsersListRequestResult
    {
        public PaginatedList<User> PaginatedList { get; set; }
    }
}