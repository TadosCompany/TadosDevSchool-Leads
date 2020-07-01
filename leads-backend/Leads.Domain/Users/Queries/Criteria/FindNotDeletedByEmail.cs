namespace Leads.Domain.Users.Queries.Criteria
{
    using Infrastructure.Queries.Criteria.Abstractions;


    public class FindNotDeletedByEmail : ICriterion
    {
        public FindNotDeletedByEmail(string email)
        {
            Email = email;
        }


        public string Email { get; }
    }
}