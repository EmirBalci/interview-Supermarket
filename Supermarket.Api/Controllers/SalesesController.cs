using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Domains;
using Supermarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly ISalesDetailService _salesDetailService;
        private readonly IBasketService _basketService;

        public SalesesController(ISalesService salesService, ISalesDetailService salesDetailService, IBasketService basketService)
        {
            _salesService = salesService;
            _salesDetailService = salesDetailService;
            _basketService = basketService;
        }


        [HttpPost("PayCreditCard")]
        public async Task<IActionResult> PayCreditCard(PayViewModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Alınacak ürün bulunamadı." });
            }

            if (model.Baskets == null || !model.Baskets.Any())
            {
                return BadRequest(new { Message = "Alınacak ürün bulunamadı." });
            }

            if (model.Baskets.Any(p => p.Product.IsDeleted))
            {
                return BadRequest(new { Message = "Silinmiş ürün bulunmaktadır. Sepetinizden ürünü kaldırın." });
            }

            decimal totalPrice = 0;
            foreach (var item in model.Baskets)
            {
                totalPrice += item.Piece * item.Product.Price;
            }

            Sales sales = new Sales
            {
                Id = Guid.NewGuid(),
                PaymentType = "Credit Card",
                TotalPrice = totalPrice,
                UserId = model.UserId
            };

            var res = await _salesService.Create(sales);

            foreach (var item in model.Baskets)
            {
                SalesDetail salesDetail = new SalesDetail
                {
                    SalesId = sales.Id,
                    Piece = item.Piece,
                    ProductId = item.ProductId
                };

                await _salesDetailService.Create(salesDetail);
            }

            foreach (var item in model.Baskets)
            {
                await _basketService.Delete(item);
            }

            return Ok(res);
        }

        [HttpPost("PayCash")]
        public async Task<IActionResult> PayCash(PayViewModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Alınacak ürün bulunamadı." });
            }

            if (model.Baskets == null || !model.Baskets.Any())
            {
                return BadRequest(new { Message = "Alınacak ürün bulunamadı." });
            }

            if (model.Baskets.Any(p => p.Product.IsDeleted))
            {
                return BadRequest(new { Message = "Silinmiş ürün bulunmaktadır. Sepetinizden ürünü kaldırın." });
            }

            decimal totalPrice = 0;
            foreach (var item in model.Baskets)
            {
                totalPrice += item.Piece * item.Product.Price;
            }

            Sales sales = new Sales
            {
                Id = Guid.NewGuid(),
                PaymentType = "Cash",
                TotalPrice = totalPrice,
                UserId = model.UserId
            };

            var res = await _salesService.Create(sales);

            foreach (var item in model.Baskets)
            {
                SalesDetail salesDetail = new SalesDetail
                {
                    SalesId = sales.Id,
                    Piece = item.Piece,
                    ProductId = item.ProductId
                };

                await _salesDetailService.Create(salesDetail);
            }

            foreach (var item in model.Baskets)
            {
                await _basketService.Delete(item);
            }

            return Ok(res);
        }
    }
}
