using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class MenuDataModel : BindableBase
    {
        public MenuItemsFirstPage MenuItemsFirstPage { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }
    }
}