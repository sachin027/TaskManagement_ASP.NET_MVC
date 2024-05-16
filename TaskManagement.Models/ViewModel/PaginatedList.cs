using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int Total { get; set; }

        public PaginatedList(List<T> items, int count , int pageIndex , int pageSize)
        {
            PageIndex = pageIndex;
            Total = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < Total;

        public static PaginatedList<T> Create(List<T> source , int pageIndex , int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
