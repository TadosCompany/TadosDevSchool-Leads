namespace Leads.WebApi.Application.Areas.Api.User.Requests.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Services.Abstractions;
    using Dto;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Requests.Handlers;


    public class EditUserRequestHandler : IAsyncApiRequestHandler<EditUserRequest, EditUserRequestResult>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public EditUserRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IUserService userService,
            IMapper mapper,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task<EditUserRequestResult> ExecuteAsync(
            EditUserRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindNotDeletedByIdAsync<User>(request.Id, cancellationToken);

            if (user == null)
                throw _apiExceptionFactory.Create(ErrorCodes.UserNotFound);

            await _userService.EditAsync(
                user,
                request.Email,
                request.Role,
                cancellationToken);

            return new EditUserRequestResult(_mapper.Map<UserDto>(user));
        }
    }
}