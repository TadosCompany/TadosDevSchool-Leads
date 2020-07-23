namespace Leads.Domain.Users.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Enums;
    using Events;
    using Exceptions;
    using global::Domain.Events.Raisers.Abstractions;
    using Infrastructure.Commands.Builders.Abstractions;
    using Infrastructure.Commands.Contexts.Common.Extensions;
    using Infrastructure.Queries.Builders.Abstractions;
    using Objects.Entities;
    using Queries.Criteria;


    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAsyncCommandBuilder _asyncCommandBuilder;
        private readonly IAsyncDomainEventRaiser _asyncDomainEventRaiser;



        public UserService(
            IAsyncQueryBuilder asyncQueryBuilder, 
            IAsyncCommandBuilder asyncCommandBuilder,
            IAsyncDomainEventRaiser asyncDomainEventRaiser)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
            _asyncDomainEventRaiser = asyncDomainEventRaiser ?? throw new ArgumentNullException(nameof(asyncDomainEventRaiser));
        }



        public async Task<User> CreateAsync(
            string email, 
            string password, 
            UserRoles role,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(password));

            var user = new User(email, password, role);

            User existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(
                    new FindByEmail(user.Email), 
                    cancellationToken);

            if (existingUser != null)
            {
                if (!existingUser.IsDeleted)
                {
                    throw new UserAlreadyExistsException();
                }
                else
                {
                    throw new UserExistsButDeletedException();
                }
            }

            await _asyncCommandBuilder.CreateAsync(user, cancellationToken);

            await _asyncDomainEventRaiser.RaiseAsync(
                new UserCreatedDomainEvent(user.Email, password, user.Role), 
                cancellationToken);

            return user;
        }

        public async Task EditAsync(
            User user, string email, 
            UserRoles role,
            CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));


            User existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(
                    new FindByEmail(email), 
                    cancellationToken);

            if (existingUser != null && !existingUser.Equals(user))
            {
                if (!existingUser.IsDeleted)
                {
                    throw new UserAlreadyExistsException();
                }
                else
                {
                    throw new UserExistsButDeletedException();
                }
            }

            user.Edit(email, role);
        }

        public async Task RestoreAsync(
            User user, 
            CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));


            User existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(
                    new FindByEmail(user.Email), 
                    cancellationToken);

            if (existingUser != null && !existingUser.Equals(user))
            {
                if (!existingUser.IsDeleted)
                {
                    throw new UserAlreadyExistsException();
                }
                else
                {
                    throw new UserExistsButDeletedException();
                }
            }

            user.Restore();
        }

        public async Task ResetPasswordAsync(
            User user,
            string password,
            CancellationToken cancellationToken = default)
        {
            if (user == null) 
                throw new ArgumentNullException(nameof(user));

            user.SetPassword(password);

            await _asyncDomainEventRaiser.RaiseAsync(
                new UserPasswordResetedDomainEvent(user.Email, password),
                cancellationToken);
        }
    }
}