using System;
using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class MenuItem : BindableBase
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Uri ImageUrl { get; set; }
        public string Description { get; set; }
        public long Rating { get; set; }
        public long Price { get; set; }
        public List<object> Allergens { get; set; }
    }
}
