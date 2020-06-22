namespace Infrastructure.NHibernate.Sessions.Providers
{
    using System;
    using Abstractions;
    using global::NHibernate;


    public abstract class ScopedSessionProviderBase : ISessionProvider, IDisposable
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


        protected void CommitTransaction()
        {
            _transaction?.Commit();
        }

        protected void RollbackTransaction()
        {
            _transaction?.Rollback();
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
    }
}