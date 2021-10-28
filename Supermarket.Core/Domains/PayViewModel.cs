using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Domains
{
    public class PayViewModel
    {
        public List<Basket> Baskets { get; set; }
        public Guid UserId { get; set; }
    }
}
