namespace Leads.WebApi.Application.Areas.Service.User.Requests.CreateFirstAdmin
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Enums;
    using Domain.Users.Services.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class CreateFirstAdminRequestHandler : IAsyncApiRequestHandler<CreateFirstAdminRequest>
    {
        private readonly IUserService _userService;



        public CreateFirstAdminRequestHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }



        public Task ExecuteAsync(
            CreateFirstAdminRequest request,
            CancellationToken cancellationToken = default)
        {
            return _userService.CreateAsync(
                request.Email.Trim(), 
                request.Password, 
                UserRoles.Administrator, 
                cancellationToken);
        }
    }
}