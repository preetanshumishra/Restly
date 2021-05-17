using System;
using System.Collections.Generic;

namespace Restly.Core.Models
{
    public class ProductDataModel : BindableBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public List<object> Allergens { get; set; }
        public List<object> Options { get; set; }
        public List<object> FrequentlyBoughtProducts { get; set; }
    }
}