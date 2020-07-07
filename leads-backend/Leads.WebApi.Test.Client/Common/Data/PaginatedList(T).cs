namespace Leads.WebApi.Test.Client.Common.Data
{
    using System.Collections.Generic;


    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}