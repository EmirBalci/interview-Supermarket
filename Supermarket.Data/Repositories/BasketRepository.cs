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
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(SupermarketContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Basket>> GetAllBasketsByUserIdAsync(Guid id)
        {
            return await SupermarketDbContext.Baskets.Where(x => x.UserId == id).Include("Product").ToListAsync();
        }

        public Task<Basket> GetWithBasketByIdAsync(Guid id)
        {
            return SupermarketDbContext.Baskets
               .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Basket> GetBasketsByIdAsync(Guid id)
        {
            return await SupermarketDbContext.Baskets.SingleOrDefaultAsync(x => x.Id == id);
        }

        private SupermarketContext SupermarketDbContext
        {
            get { return Context as SupermarketContext; }
        }
    }
}
