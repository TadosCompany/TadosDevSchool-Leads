namespace Leads.WebApi.Application.Areas.Api.User.Requests.ResetPassword
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Queries.Criteria.Extensions;
    using Domain.Users.Objects.Entities;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Infrastructure.Exceptions.Factories.Abstractions;
    using Infrastructure.Messaging;
    using Infrastructure.Requests.Handlers;
    using Infrastructure.Security.Passwords;


    public class ResetPasswordRequestHandler : IAsyncApiRequestHandler<ResetPasswordRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IPasswordGenerator _passwordGenerator;
        private readonly IEmailMessageSender _emailMessageSender;
        private readonly IApiExceptionFactory _apiExceptionFactory;


        public ResetPasswordRequestHandler(
            IAsyncQueryBuilder queryBuilder,
            IPasswordGenerator passwordGenerator,
            IEmailMessageSender emailMessageSender,
            IApiExceptionFactory apiExceptionFactory)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _passwordGenerator = passwordGenerator ?? throw new ArgumentNullException(nameof(passwordGenerator));
            _emailMessageSender = emailMessageSender ?? throw new ArgumentNullException(nameof(emailMessageSender));
            _apiExceptionFactory = apiExceptionFactory ?? throw new ArgumentNullException(nameof(apiExceptionFactory));
        }


        public async Task ExecuteAsync(
            ResetPasswordRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _queryBuilder.FindNotDeletedByIdAsync<User>(request.Id, cancellationToken);

            if (user == null)
                throw _apiExceptionFactory.Create(ErrorCodes.UserNotFound);

            var password = _passwordGenerator.Generate();

            user.SetPassword(password);

            await _emailMessageSender.SendMessageAsync(
                user.Email,
                "Ваш пароль сброшен",
                $"Логин: {user.Email}{Environment.NewLine}Пароль: {password}");
        }
    }
}