﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Core.Domains
{
    public partial class Basket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Piece { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
