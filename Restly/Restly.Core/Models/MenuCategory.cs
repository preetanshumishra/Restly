namespace Restly.Core.Models
{
    public class MenuCategory : BindableBase
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}