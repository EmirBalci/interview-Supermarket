using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Core.Domains
{
    public partial class User
    {
        public User()
        {
            Baskets = new HashSet<Basket>();
            Sales = new HashSet<Sales>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
