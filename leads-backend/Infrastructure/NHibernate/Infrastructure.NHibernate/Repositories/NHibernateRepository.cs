namespace Infrastructure.NHibernate.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::NHibernate;
    using Identification.Abstractions;
    using Infrastructure.Repositories.Abstractions;
    using Sessions.Providers.Abstractions;


    public class NHibernateRepository<THasId> : IRepository<THasId>
        where THasId : class, IHasId, new()
    {
        private readonly ISessionProvider _sessionProvider;


        public NHibernateRepository(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider ?? throw new ArgumentNullException(nameof(sessionProvider));
        }


        protected ISession Session => _sessionProvider.CurrentSession;
        

        public List<THasId> GetAll()
        {
            return Session.Query<THasId>().ToList();
        }

        public void Add(THasId objectWithId)
        {
            Session.SaveOrUpdate(objectWithId);
        }

        public THasId GetById(long id)
        {
            return Session.Query<THasId>().SingleOrDefault(x => x.Id == id);
        }

        public void Delete(THasId objectWithId)
        {
            Session.Delete(objectWithId);
        }
    }
}