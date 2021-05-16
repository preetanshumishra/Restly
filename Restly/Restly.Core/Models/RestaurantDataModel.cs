using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class RestaurantDataModel
    {
        public RestaurantFirstPageModel RestaurantFirstPage { get; set; }
        public List<RestaurantsCategoryModel> RestaurantsCategories { get; set; }
    }
}