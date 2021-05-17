namespace Restly.Core.Models
{
    public class RestaurantModel : BindableBase
    {
        public string Categories { get; set; }
        public double Rating { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}