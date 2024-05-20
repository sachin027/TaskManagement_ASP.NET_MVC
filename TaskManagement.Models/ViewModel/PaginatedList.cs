using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
    public class PaginatedList<T> : List<T>
    {
        public static int totalCount;
        public static int page;
        public static int pageSize;
        public static int totalPage;

        public static List<T> Pagination(List<T> _list, int page)
        {
            int pageSize = 5;

            int totalCount = _list.Count();
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var DetailsPerPage = _list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PaginatedList<T>.totalCount = totalCount;
            PaginatedList<T>.page = page;
            PaginatedList<T>.pageSize = pageSize;
            PaginatedList<T>.totalPage = totalPage;
            return DetailsPerPage;
        }
    }
}
