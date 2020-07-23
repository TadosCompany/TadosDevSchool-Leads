namespace Application.Events.Stores.Processors.AfterCommit
{
    using System;
    using System.Threading.Tasks;
    using Buses.Abstractions;
    using Default;
    using Domain.Events.Stores.Abstractions;
    using Infrastructure.Transactions.Notifications.Abstractions;
    using Mappers.Builders.Abstractions;

    public class AfterCommitAsyncDomainToApplicationEventStoreProcessor : DefaultAsyncDomainToApplicationEventStoreProcessor, IDisposable
    {
        private readonly ICommitNotifier _commitNotifier;



        public AfterCommitAsyncDomainToApplicationEventStoreProcessor(
            IAsyncDomainEventStore asyncDomainEventStore, 
            IDomainToApplicationEventMapperBuilder domainToApplicationEventMapperBuilder, 
            IAsyncApplicationEventBus asyncApplicationEventBus,
            ICommitNotifier commitNotifier) 
            : base(
                asyncDomainEventStore, 
                domainToApplicationEventMapperBuilder,
                asyncApplicationEventBus)
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



        private void OnAfterCommit(object sender, EventArgs e) => Task.Run(() => ProcessAsync());
    }
}
