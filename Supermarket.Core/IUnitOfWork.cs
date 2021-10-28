using Supermarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IBasketRepository Basket { get; }
        IProductRepository Product { get; }
        ISalesRepository Sales { get; }
        ISalesDetailRepository SalesDetail { get; }
        Task<int> CommitAsync();
    }
}
