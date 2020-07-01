namespace Leads.WebApi.Application.Areas.Api.User.Filters
{
    using Domain.Users.Enums;


    public class AdminUserFilter
    {
        public UserRoles[] Roles { get; set; }
        
        public bool ShowDeleted { get; set; }
        
        public string SearchString { get; set; }
    }
}