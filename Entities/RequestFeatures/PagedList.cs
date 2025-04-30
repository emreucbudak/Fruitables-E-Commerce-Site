using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData Metadata { get; set; }
        public PagedList(List<T> items, int pageNumber, int pageSize, int count)
        {
            Metadata = new MetaData()
            {

                CurrentPage = pageNumber,
                TotalCount = count,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)

            };
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> items, int pagesize, int pagenumber)
        {
            var count = items.Count();
            var source = items.Skip((pagenumber-1) * pagesize).Take(pagesize).ToList();

            return new PagedList<T>(source, pagenumber, pagesize, count);
        }
    }
}
