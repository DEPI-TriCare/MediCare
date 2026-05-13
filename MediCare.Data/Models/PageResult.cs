using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PageResult <T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();
        public bool HasPrev => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
    }
}
