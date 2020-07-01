namespace Leads.Persistence.Users.User.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Queries.Criteria;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindNotDeletedUserByEmailAsyncQuery
        : LinqAsyncQueryBase<User, FindNotDeletedByEmail, User>
    {
        public FindNotDeletedUserByEmailAsyncQuery(ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<User> AskAsync(FindNotDeletedByEmail criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(
                x => x.DeletedAtUtc == null && x.Email == criterion.Email,
                cancellationToken);
        }
    }
}