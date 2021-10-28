using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Domains;
using Supermarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SupermarketContext context)
            : base(context)
        { }

        private SupermarketContext SupermarketDbContext
        {
            get { return Context as SupermarketContext; }
        }
    }
}
