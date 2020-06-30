namespace Infrastructure.NHibernate.Sessions.Providers
{
    using System;
    using Abstractions;
    using global::NHibernate;
    using Transactions.Notifications.Abstractions;


    public abstract class ScopedSessionProviderBase : 
        ISessionProvider,
        ICommitNotifier,
        IRollbackNotifier,
        IDisposable
    {
        private readonly ISessionFactory _sessionFactory;

        private ISession _session;
        private ITransaction _transaction;


        protected ScopedSessionProviderBase(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        protected bool IsDisposed { get; set; }


        public ISession CurrentSession
        {
            get
            {
                if (IsDisposed)
                    throw new InvalidOperationException("Object already disposed");

                if (_session != null)
                    return _session;

                _session = _sessionFactory.OpenSession();

                _transaction = _session.BeginTransaction();

                return _session;
            }
        }
        
        public event EventHandler BeforeCommit;
        public event EventHandler AfterCommit;
        public event EventHandler BeforeRollback;
        public event EventHandler AfterRollback;


        protected void CommitTransaction()
        {
            try
            {
                OnBeforeCommit();
            }
            catch (Exception)
            {
                // TODO : inject logger and log
            }
            
            _transaction?.Commit();
            
            try
            {
                OnAfterCommit();
            }
            catch (Exception)
            {
                // TODO : inject logger and log
            }
        }

        protected void RollbackTransaction()
        {
            try
            {
                OnBeforeRollback();
            }
            catch (Exception)
            {
                // TODO : inject logger and log
            }
            
            _transaction?.Rollback();
            
            try
            {
                OnAfterRollback();
            }
            catch (Exception)
            {
                // TODO : inject logger and log
            }
        }
        
        
        protected virtual void OnDispose()
        {
        }



        #region IDisposable implementation

        public void Dispose()
        {
            if (IsDisposed)
                return;

            try
            {
                OnDispose();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;

                _session?.Dispose();
                _session = null;

                IsDisposed = true;
            }
        }

        #endregion

        protected virtual void OnBeforeCommit()
        {
            BeforeCommit?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnAfterCommit()
        {
            AfterCommit?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnBeforeRollback()
        {
            BeforeRollback?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnAfterRollback()
        {
            AfterRollback?.Invoke(this, EventArgs.Empty);
        }
    }
}