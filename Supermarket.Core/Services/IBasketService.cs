using Supermarket.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> GetAllBasketByUserId(Guid id);
        Task<Basket> GetBasketById(Guid id);
        Task<Basket> GetByProductId(Guid id);
        Task<Basket> Create(Basket newBasket);
        Task<bool> Update(Basket basket);
        Task<bool> Drop(Basket basket);
        Task Delete(Basket basket);
    }
}
