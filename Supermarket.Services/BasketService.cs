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
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Basket> Create(Basket newBasket)
        {
            await _unitOfWork.Basket.AddAsync(newBasket);
            var isAdded = await _unitOfWork.CommitAsync();

            if (isAdded < 1)
            {
                throw new Exception("Ürün sepete eklenemedi !!");
            }

            return newBasket;
        }

        public async Task Delete(Basket basket)
        {
            _unitOfWork.Basket.Remove(basket);
            var isDeleted = await _unitOfWork.CommitAsync();

            if (isDeleted < 1)
            {
                throw new Exception("Ürün silinemedi !!");
            }
        }

        public async Task<Basket> GetBasketById(Guid id)
        {
            var basket = await _unitOfWork.Basket.GetBasketsByIdAsync(id);

            if (basket == null)
            {
                throw new Exception("Sepet bulunamadı !!");
            }

            return basket;
        }

        public async Task<IEnumerable<Basket>> GetAllBasketByUserId(Guid id)
        {
            var basket = await _unitOfWork.Basket.GetAllBasketsByUserIdAsync(id);

            if (basket == null)
            {
                throw new Exception("Kullanıcının sepette ürünü yok !!");
            }

            return basket;
        }

        public async Task<Basket> GetByProductId(Guid id)
        {
            var basket = await _unitOfWork.Basket.SingleOrDefaultAsync(x => x.ProductId == id);

            if (basket == null)
            {
                throw new Exception("Sepette ürün bulunamadı !!");
            }

            return basket;
        }

        public async Task<bool> Update(Basket basket)
        {
            var oldBasket = await _unitOfWork.Basket.SingleOrDefaultAsync(x => x.Id == basket.Id);

            if (oldBasket == null)
            {
                throw new Exception("Değiştirilmek istenen ürün sepette bulunamadı !!");
            }

            oldBasket.Piece++;
            var isUpdated = await _unitOfWork.CommitAsync();

            if (isUpdated < 1)
            {
                throw new Exception("Sepetteki ürün güncellenemedi !!");
            }

            var product = await _unitOfWork.Product.SingleOrDefaultAsync(x => x.Id == basket.ProductId);

            if (product == null)
            {
                throw new Exception("Stokta ürün bulunamadı !!");
            }

            product.Stock--;

            var isUpdatedStock = await _unitOfWork.CommitAsync();

            if (isUpdatedStock < 1)
            {
                throw new Exception("Stoktaki ürünün stok sayısı güncellenemedi !!");
            }

            return true;
        }

        public async Task<bool> Drop(Basket basket)
        {
            var oldBasket = await _unitOfWork.Basket.SingleOrDefaultAsync(x => x.Id == basket.Id);

            if (oldBasket == null)
            {
                throw new Exception("Değiştirilmek istenen ürün sepette bulunamadı !!");
            }

            oldBasket.Piece--;
            var isUpdated = await _unitOfWork.CommitAsync();

            if (isUpdated < 1)
            {
                throw new Exception("Sepetteki ürün güncellenemedi !!");
            }

            var product = await _unitOfWork.Product.SingleOrDefaultAsync(x => x.Id == basket.ProductId);

            if (product == null)
            {
                throw new Exception("Stokta ürün bulunamadı !!");
            }

            product.Stock++;

            var isUpdatedStock = await _unitOfWork.CommitAsync();

            if (isUpdatedStock < 1)
            {
                throw new Exception("Stoktaki ürünün stok sayısı güncellenemedi !!");
            }

            return true;
        }
    }
}
