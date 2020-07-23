namespace Application.Events.Stores.Processors.AfterCommit
{
    using System;
    using Buses.Abstractions;
    using Default;
    using Domain.Events.Stores.Abstractions;
    using Infrastructure.Transactions.Notifications.Abstractions;
    using Mappers.Builders.Abstractions;

    public class AfterCommitDomainToApplicationEventStoreProcessor : DefaultDomainToApplicationEventStoreProcessor, IDisposable
    {
        private readonly ICommitNotifier _commitNotifier;



        public AfterCommitDomainToApplicationEventStoreProcessor(
            IDomainEventStore domainEventStore, 
            IDomainToApplicationEventMapperBuilder domainToApplicationEventMapperBuilder, 
            IApplicationEventBus applicationEventBus,
            ICommitNotifier commitNotifier) 
            : base(
                domainEventStore, 
                domainToApplicationEventMapperBuilder, 
                applicationEventBus)
        {
            _commitNotifier = commitNotifier ?? throw new ArgumentNullException(nameof(commitNotifier));

            _commitNotifier.AfterCommit += OnAfterCommit;
        }



        public void Dispose()
        {
            if (_commitNotifier != null)
            {
                _commitNotifier.AfterCommit -= OnAfterCommit;
            }
        }



        private void OnAfterCommit(object sender, EventArgs e) => Process();
    }
}
