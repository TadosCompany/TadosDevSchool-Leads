namespace Leads.WebApi.Application.Infrastructure.Pagination
{
    using System;
    using System.Collections.Generic;


    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int totalCount)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            TotalCount = totalCount;
        }


        public List<T> Items { get; }

        public int TotalCount { get; }
    }
}