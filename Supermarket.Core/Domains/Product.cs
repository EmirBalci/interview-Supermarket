using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Core.Domains
{
    public partial class Product
    {
        public Product()
        {
            Baskets = new HashSet<Basket>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Stock { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
