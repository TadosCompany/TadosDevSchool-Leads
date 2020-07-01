namespace Leads.WebApi.Application.Areas.Api.User.Dto
{
    using Domain.Users.Enums;


    public class UserDto
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public UserRoles Role { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}