namespace Leads.WebApi.Application.Areas.Api.User.Requests.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using Dto;
    using Infrastructure.Messaging;
    using Infrastructure.Requests.Handlers;
    using Infrastructure.Security.Passwords;


    public class AddUserRequestHandler : IAsyncApiRequestHandler<AddUserRequest, AddUserRequestResult>
    {
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IEmailMessageSender _emailMessageSender;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public AddUserRequestHandler(
            IPasswordGenerator passwordGenerator,
            IEmailMessageSender emailMessageSender,
            IUserService userService,
            IMapper mapper)
        {
            _passwordGenerator = passwordGenerator ?? throw new ArgumentNullException(nameof(passwordGenerator));
            _emailMessageSender = emailMessageSender ?? throw new ArgumentNullException(nameof(emailMessageSender));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<AddUserRequestResult> ExecuteAsync(
            AddUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var password = _passwordGenerator.Generate();

            var user = new User(
                request.Email,
                password,
                request.Role);

            await _userService.CreateAsync(user, cancellationToken);

            // TODO : message templates
            await _emailMessageSender.SendMessageAsync(
                request.Email,
                "Ваша учетная запись",
                $"Логин: {user.Email}{Environment.NewLine}Пароль: {password}");

            return new AddUserRequestResult(_mapper.Map<UserDto>(user));
        }
    }
}