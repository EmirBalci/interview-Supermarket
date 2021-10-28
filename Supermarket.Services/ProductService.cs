using Supermarket.Core;
using Supermarket.Core.Domains;
using Supermarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Create(Product newProduct)
        {
            newProduct.Id = Guid.NewGuid();
            await _unitOfWork.Product.AddAsync(newProduct);
            var isAdded = await _unitOfWork.CommitAsync();

            if (isAdded < 1)
            {
                throw new Exception("Ürün Eklenemedi !!");
            }

            return newProduct;
        }

        public async Task<bool> Delete(Guid id)
        {
            var oldProduct = await _unitOfWork.Product.SingleOrDefaultAsync(x => x.Id == id);

            if (oldProduct == null)
            {
                throw new Exception("Ürün bulunamadı !!");
            }

            oldProduct.IsDeleted = true;
            var isUpdated = await _unitOfWork.CommitAsync();

            if (isUpdated < 1)
            {
                throw new Exception("Silme işlemi gerçekleşmedi !!");
            }

            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _unitOfWork.Product.GetAllAsync(x => x.IsDeleted == false);

            if (products == null)
            {
                throw new Exception("Hiç ürün bulunamadı !!");
            }

            return products;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _unitOfWork.Product.SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı !!");
            }

            return product;
        }

        public async Task<bool> Update(Product product)
        {
            var oldProduct = await _unitOfWork.Product.SingleOrDefaultAsync(x => x.Id == product.Id);

            if (oldProduct == null)
            {
                throw new Exception("Güncellenecek ürün bulunamadı !!");
            }

            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Stock = product.Stock;
            oldProduct.Type = product.Type;

            var isUpdated = _unitOfWork.CommitAsync().Result;

            if (isUpdated < 1)
            {
                throw new Exception("Ürün güncellenemedi !!");
            }

            return true;
        }
    }
}
