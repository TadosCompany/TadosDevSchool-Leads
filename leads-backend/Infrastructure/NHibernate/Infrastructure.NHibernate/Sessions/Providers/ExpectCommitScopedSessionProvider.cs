namespace Infrastructure.NHibernate.Sessions.Providers
{
    using System;
    using global::NHibernate;
    using Transactions.Behaviors;


    public class ExpectCommitScopedSessionProvider : ScopedSessionProviderBase, IExpectCommit
    {
        public ExpectCommitScopedSessionProvider(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }


        public void PerformCommit()
        {
            if (IsDisposed)
                throw new InvalidOperationException("Object already disposed");

            try
            {
                CommitTransaction();
            }
            catch
            {
                RollbackTransaction();

                throw;
            }
            finally
            {
                Dispose();
            }
        }
    }
}