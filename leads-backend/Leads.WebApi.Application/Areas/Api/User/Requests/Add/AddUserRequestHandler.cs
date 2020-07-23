namespace Leads.WebApi.Application.Areas.Api.User.Requests.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using Dto;
    using Infrastructure.Requests.Handlers;
    using Infrastructure.Security.Passwords;


    public class AddUserRequestHandler : IAsyncApiRequestHandler<AddUserRequest, AddUserRequestResult>
    {
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;



        public AddUserRequestHandler(
            IPasswordGenerator passwordGenerator,
            IUserService userService,
            IMapper mapper)
        {
            _passwordGenerator = passwordGenerator ?? throw new ArgumentNullException(nameof(passwordGenerator));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<AddUserRequestResult> ExecuteAsync(
            AddUserRequest request,
            CancellationToken cancellationToken = default)
        {
            string password = _passwordGenerator.Generate();

            User user = await _userService.CreateAsync(request.Email, password, request.Role, cancellationToken);

            return new AddUserRequestResult(_mapper.Map<UserDto>(user));
        }
    }
}