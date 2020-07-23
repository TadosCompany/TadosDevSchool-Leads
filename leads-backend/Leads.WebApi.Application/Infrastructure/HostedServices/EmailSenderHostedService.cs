namespace Leads.WebApi.Application.Infrastructure.HostedServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Events.UserCreated;
    using Events.UserPasswordReseted;
    using global::Application.Events.Buses.Abstractions;
    using global::Events.Buses.Abstractions;
    using Messaging;
    using Microsoft.Extensions.Hosting;

    public class EmailSenderHostedService : IHostedService
    {
        private readonly IAsyncApplicationEventBus _asyncApplicationEventBus;
        private readonly IEmailMessageSender _emailMessageSender;

        private readonly IList<IEventSubscriptionToken> _subscriptionTokens = new List<IEventSubscriptionToken>();



        public EmailSenderHostedService(
            IAsyncApplicationEventBus asyncApplicationEventBus, 
            IEmailMessageSender emailMessageSender)
        {
            _asyncApplicationEventBus = asyncApplicationEventBus ?? throw new ArgumentNullException(nameof(asyncApplicationEventBus));
            _emailMessageSender = emailMessageSender ?? throw new ArgumentNullException(nameof(emailMessageSender));
        }



        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriptionTokens.Add(
                await _asyncApplicationEventBus
                    .SubscribeAsync(async (UserCreatedApplicationEvent @event) =>
                    {
                        await _emailMessageSender.SendMessageAsync(
                            @event.Email,
                            "Ваша учетная запись",
                            $"Логин: {@event.Email}{Environment.NewLine}Пароль: {@event.Password}");
                    }));

            _subscriptionTokens.Add(
                await _asyncApplicationEventBus
                    .SubscribeAsync(async (UserPasswordResetedApplicationEvent @event) =>
                    {
                        await _emailMessageSender.SendMessageAsync(
                            @event.Email,
                            "Ваш пароль сброшен",
                            $"Логин: {@event.Email}{Environment.NewLine}Пароль: {@event.Password}");
                    }));
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
