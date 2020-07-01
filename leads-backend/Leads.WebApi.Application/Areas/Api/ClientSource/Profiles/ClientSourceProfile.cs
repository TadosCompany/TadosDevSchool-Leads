namespace Leads.WebApi.Application.Areas.Api.ClientSource.Profiles
{
    using AutoMapper;
    using Domain.Clients.Objects.Entities;
    using Dto;


    public class ClientSourceProfile : Profile
    {
        public ClientSourceProfile()
        {
            CreateMap<ClientSource, ClientSourceDto>();
        }
    }
}