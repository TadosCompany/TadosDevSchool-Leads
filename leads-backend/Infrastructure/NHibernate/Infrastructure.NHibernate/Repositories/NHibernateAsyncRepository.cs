namespace Infrastructure.NHibernate.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::NHibernate;
    using global::NHibernate.Linq;
    using Identification.Abstractions;
    using Infrastructure.Repositories.Abstractions;
    using Sessions.Providers.Abstractions;


    public class NHibernateAsyncRepository<THasId> : IAsyncRepository<THasId>
        where THasId : class, IHasId, new()
    {
        private readonly ISessionProvider _sessionProvider;


        public NHibernateAsyncRepository(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider ?? throw new ArgumentNullException(nameof(sessionProvider));
        }


        protected ISession Session => _sessionProvider.CurrentSession;


        public Task<List<THasId>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Session.Query<THasId>().ToListAsync(cancellationToken);
        }

        public Task AddAsync(THasId objectWithId, CancellationToken cancellationToken = default)
        {
            return Session.SaveOrUpdateAsync(objectWithId, cancellationToken);
        }

        public Task<THasId> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return Session.Query<THasId>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task DeleteAsync(THasId objectWithId, CancellationToken cancellationToken = default)
        {
            return Session.DeleteAsync(objectWithId, cancellationToken);
        }
    }
}