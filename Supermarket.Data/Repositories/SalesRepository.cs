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
    public class SalesRepository : Repository<Sales>, ISalesRepository
    {
        public SalesRepository(SupermarketContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<Sales>> GetAllSalesesAsync()
        {
            return await SupermarketDbContext.Sales
                .ToListAsync();
        }

        public Task<Sales> GetWithSalesByIdAsync(Guid id)
        {
            return SupermarketDbContext.Sales
               .SingleOrDefaultAsync(a => a.Id == id);
        }

        private SupermarketContext SupermarketDbContext
        {
            get { return Context as SupermarketContext; }
        }
    }
}
