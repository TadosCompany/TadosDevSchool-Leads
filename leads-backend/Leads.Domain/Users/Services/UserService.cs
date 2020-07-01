namespace Leads.Domain.Users.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Enums;
    using Exceptions;
    using Infrastructure.Commands.Builders.Abstractions;
    using Infrastructure.Commands.Contexts.Common.Extensions;
    using Infrastructure.Queries.Builders.Abstractions;
    using Objects.Entities;
    using Queries.Criteria;


    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IAsyncCommandBuilder _asyncCommandBuilder;


        public UserService(IAsyncQueryBuilder asyncQueryBuilder, IAsyncCommandBuilder asyncCommandBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
        }


        public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(new FindByEmail(user.Email), cancellationToken);

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
        }

        public async Task EditAsync(User user, string email, UserRoles role,
            CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));

            var existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(new FindByEmail(email), cancellationToken);

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

        public async Task RestoreAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await _asyncQueryBuilder
                .For<User>()
                .WithAsync(new FindByEmail(user.Email), cancellationToken);

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
    }
}