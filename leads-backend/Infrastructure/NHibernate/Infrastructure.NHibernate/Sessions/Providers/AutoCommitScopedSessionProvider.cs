namespace Infrastructure.NHibernate.Sessions.Providers
{
    using global::NHibernate;
    using Transactions.Behaviors;


    public class AutoCommitScopedSessionProvider : ScopedSessionProviderBase, IPerformAutoCommit
    {
        private bool _preventCommit;
        
        
        public AutoCommitScopedSessionProvider(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }


        public void PreventAutoCommit()
        {
            _preventCommit = true;
        }
        
        protected override void OnDispose()
        {
            if (!_preventCommit)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    RollbackTransaction();

                    throw;
                }
            }
            else
            {
                RollbackTransaction();
            }
        }
    }
}