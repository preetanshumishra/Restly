namespace Restly.Core.Models
{
    public class RestaurantsCategoryModel : BindableBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}