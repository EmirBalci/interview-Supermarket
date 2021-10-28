using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Supermarket.Core.Domains
{
    public partial class SalesDetail
    {
        public Guid Id { get; set; }
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public int Piece { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
