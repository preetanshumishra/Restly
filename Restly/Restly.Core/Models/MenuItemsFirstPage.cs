using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class MenuItemsFirstPage
    {
        public List<MenuItem> Data { get; set; }
        public long TotalPages { get; set; }
        public long CurrentPage { get; set; }
        public long ActiveIndex { get; set; }
        public long TotalElementsCount { get; set; }
    }
}