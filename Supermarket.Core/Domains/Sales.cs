using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Core.Domains
{
    public partial class Sales
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }

        public virtual User User { get; set; }
    }
}
