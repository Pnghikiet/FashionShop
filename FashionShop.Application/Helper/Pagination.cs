using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Helper
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int totalItem, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItem = totalItem;
            Data = data;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItem {  get; set; }

        public IReadOnlyList<T> Data { get; set; }
        
    }
}
