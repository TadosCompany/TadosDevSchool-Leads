namespace Leads.WebApi.Application.Infrastructure.Authorization.Providers
{
    using System;
    using System.Security.Claims;using Domain.Common;
    using Domain.Common.Queries.Criteria.Extensions;
    using global::Infrastructure.Domain.Entities.Abstractions;
    using global::Infrastructure.Queries.Builders.Abstractions;
    using Microsoft.AspNetCore.Http;


    public class IdClaimBasedUserProvider<TUser> : UserProviderBase<TUser>
        where TUser : class, IEntity, IDummyDeletable, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IQueryBuilder _queryBuilder;

        private TUser _user;


        public IdClaimBasedUserProvider(
            IHttpContextAccessor httpContextAccessor,
            IQueryBuilder queryBuilder)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
        }


        protected override TUser GetUser()
        {
            if (_user != null)
                return _user;

            if (_httpContextAccessor.HttpContext.User.Identity == null ||
                !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return default;

            Claim nameIdentifierClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim == null)
                return default;

            if (!long.TryParse(nameIdentifierClaim.Value, out long id))
                return default;

            _user = _queryBuilder.FindNotDeletedById<TUser>(id);

            return _user;
        }
    }
}