namespace Leads.WebApi.Application.Infrastructure.HostedServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Events.UserCreated;
    using global::Application.Events.Buses.Abstractions;
    using global::Events.Buses.Abstractions;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class EmailSender : IHostedService
    {
        private readonly IAsyncApplicationEventBus _asyncApplicationEventBus;
        private readonly ILogger<EmailSender> _logger;

        private readonly IList<IEventSubscriptionToken> _subscriptionTokens = new List<IEventSubscriptionToken>();



        public EmailSender(
            IAsyncApplicationEventBus asyncApplicationEventBus, 
            ILogger<EmailSender> logger)
        {
            _asyncApplicationEventBus = asyncApplicationEventBus ?? throw new ArgumentNullException(nameof(asyncApplicationEventBus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        public async Task StartAsync(CancellationToken cancellationToken)
        {
            IEventSubscriptionToken subscriptionToken = await _asyncApplicationEventBus
                .SubscribeAsync((UserCreatedApplicationEvent @event) =>
                {
                    _logger.LogWarning($"Мы отправили письмо на почту {@event.Email}");
                });

            _subscriptionTokens.Add(subscriptionToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (IEventSubscriptionToken subscriptionToken in _subscriptionTokens)
            {
                await _asyncApplicationEventBus.UnsubscribeAsync(subscriptionToken);
            }
        }
    }
}
