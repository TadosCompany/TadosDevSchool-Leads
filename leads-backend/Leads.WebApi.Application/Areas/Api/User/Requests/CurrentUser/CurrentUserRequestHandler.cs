namespace Leads.WebApi.Application.Areas.Api.User.Requests.CurrentUser
{
    using System;
    using AutoMapper;
    using Domain.Users.Objects.Entities;
    using Dto;
    using Infrastructure.Authorization.Providers;
    using Infrastructure.Requests.Handlers;


    public class CurrentUserRequestHandler : IApiRequestHandler<CurrentUserRequest, CurrentUserRequestResult>
    {
        private readonly IUserProvider<User> _userProvider;
        private readonly IMapper _mapper;


        public CurrentUserRequestHandler(
            IUserProvider<User> userProvider,
            IMapper mapper)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public CurrentUserRequestResult Execute(CurrentUserRequest request)
        {
            return new CurrentUserRequestResult(_mapper.Map<UserDto>(_userProvider.User));
        }
    }
}