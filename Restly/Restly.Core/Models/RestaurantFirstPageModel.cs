using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class RestaurantFirstPageModel : BindableBase
    {
        public List<RestaurantModel> Data { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int ActiveIndex { get; set; }
        public int TotalElementsCount { get; set; }
    }
}