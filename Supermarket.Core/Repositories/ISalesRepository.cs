using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories
{
    public interface ISalesRepository : IRepository<Sales>
    {
        Task<IEnumerable<Sales>> GetAllSalesesAsync();
        Task<Sales> GetWithSalesByIdAsync(Guid id);
    }
}
