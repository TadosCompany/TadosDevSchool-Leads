namespace Leads.WebApi.Test.Client.Users.Data
{
    public class AdminUserFilter
    {
        public AdminUserFilter(UserRoles[] roles, bool showDeleted, string searchString)
        {
            Roles = roles;
            ShowDeleted = showDeleted;
            SearchString = searchString;
        }


        public UserRoles[] Roles { get; }

        public bool ShowDeleted { get; }

        public string SearchString { get; }
    }
}