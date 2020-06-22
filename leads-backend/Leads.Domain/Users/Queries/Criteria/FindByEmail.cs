namespace Leads.Domain.Users.Queries.Criteria
{
    using Infrastructure.Queries.Criteria.Abstractions;


    public class FindByEmail : ICriterion
    {
        public FindByEmail(string email)
        {
            Email = email;
        }


        public string Email { get; }
    }
}