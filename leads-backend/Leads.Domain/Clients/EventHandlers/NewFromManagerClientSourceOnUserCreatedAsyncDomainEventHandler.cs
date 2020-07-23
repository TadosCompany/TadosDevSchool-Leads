namespace Leads.Domain.Clients.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using global::Domain.Events.Handlers.Abstractions;
    using Objects.Entities;
    using Services.ClientSource.Abstractions;
    using Users.Enums;
    using Users.Events;

    public class NewFromManagerClientSourceOnUserCreatedAsyncDomainEventHandler : IAsyncDomainEventHandler<UserCreatedDomainEvent>
    {
        private readonly IClientSourceService _clientSourceService;



        public NewFromManagerClientSourceOnUserCreatedAsyncDomainEventHandler(IClientSourceService clientSourceService)
        {
            _clientSourceService = clientSourceService;
        }



        public Task HandleAsync(UserCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            if (@event.User.Role != UserRoles.Manager)
                return Task.CompletedTask;

            var fromManagerClientSource = new ClientSource($"От менеджера {@event.User.Email}");

            return _clientSourceService.CreateAsync(fromManagerClientSource, cancellationToken);
        }
    }
}
