using Supermarket.Core;
using Supermarket.Core.Repositories;
using Supermarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SupermarketContext _context;
        private UserRepository _userRepository;
        private BasketRepository _basketRepository;
        private ProductRepository _productRepository;
        private SalesRepository _salesRepository;
        private SalesDetailRepository _salesDetailRepository;

        public UnitOfWork(SupermarketContext context)
        {
            this._context = context;
        }

        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);
        public IBasketRepository Basket => _basketRepository = _basketRepository ?? new BasketRepository(_context);
        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);
        public ISalesRepository Sales => _salesRepository = _salesRepository ?? new SalesRepository(_context);
        public ISalesDetailRepository SalesDetail => _salesDetailRepository = _salesDetailRepository ?? new SalesDetailRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
