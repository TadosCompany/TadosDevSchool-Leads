namespace Leads.Domain.Clients.Services.ClientSource
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Common.Queries.Criteria;
    using Exceptions;
    using Infrastructure.Commands.Builders.Abstractions;
    using Infrastructure.Commands.Contexts.Common.Extensions;
    using Infrastructure.Queries.Builders.Abstractions;
    using Objects.Entities;


    public class ClientSourceService : IClientSourceService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;


        public ClientSourceService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }


        public async Task CreateAsync(
            ClientSource clientSource,
            CancellationToken cancellationToken = default)
        {
            if (clientSource == null)
                throw new ArgumentNullException(nameof(clientSource));

            var existingClientSource = await _queryBuilder
                .For<ClientSource>()
                .WithAsync(new FindByName(clientSource.Name), cancellationToken);

            if (existingClientSource != null)
            {
                if (!existingClientSource.IsDeleted)
                {
                    throw new ClientSourceAlreadyExistsException();
                }
                else
                {
                    throw new ClientSourceExistsButDeletedException();
                }
            }


            await _commandBuilder.CreateAsync(clientSource, cancellationToken);
        }

        public async Task EditAsync(
            ClientSource clientSource,
            string name,
            CancellationToken cancellationToken = default)
        {
            if (clientSource == null)
                throw new ArgumentNullException(nameof(clientSource));

            var existingClientSource = await _queryBuilder
                .For<ClientSource>()
                .WithAsync(new FindByName(name), cancellationToken);

            if (existingClientSource != null && !existingClientSource.Equals(clientSource))
            {
                if (!existingClientSource.IsDeleted)
                {
                    throw new ClientSourceAlreadyExistsException();
                }
                else
                {
                    throw new ClientSourceExistsButDeletedException();
                }
            }

            clientSource.Edit(name);
        }

        public async Task RestoreAsync(ClientSource clientSource, CancellationToken cancellationToken = default)
        {
            if (clientSource == null)
                throw new ArgumentNullException(nameof(clientSource));

            var existingClientSource = await _queryBuilder
                .For<ClientSource>()
                .WithAsync(new FindByName(clientSource.Name), cancellationToken);

            if (existingClientSource != null && !existingClientSource.Equals(clientSource))
            {
                if (!existingClientSource.IsDeleted)
                {
                    throw new ClientSourceAlreadyExistsException();
                }
                else
                {
                    throw new ClientSourceExistsButDeletedException();
                }
            }

            clientSource.Restore();
        }
    }
}