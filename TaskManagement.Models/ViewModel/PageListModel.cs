using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.ViewModel
{
    public class PageListModel<T>
    {
        public int Offset { get; set; }
        public int Length { get; set; }
        public int Total { get; set; }
        public List<T> list = new List<T>();
    }
}
