namespace Leads.WebApi.Application.Areas.Api.User.Profiles
{
    using AutoMapper;
    using Domain.Users.Objects.Entities;
    using Dto;


    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}