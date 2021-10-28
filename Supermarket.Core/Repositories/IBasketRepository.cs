using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<IEnumerable<Basket>> GetAllBasketsByUserIdAsync(Guid id);
        Task<Basket> GetBasketsByIdAsync(Guid id);
        Task<Basket> GetWithBasketByIdAsync(Guid id);
    }
}
