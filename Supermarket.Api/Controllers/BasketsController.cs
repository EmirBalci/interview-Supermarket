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
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("AddBasket")]
        public async Task<IActionResult> AddBasket(Basket basket)
        {
            var isThere = await _basketService.GetByProductId(basket.ProductId);

            if (isThere != null)
            {
                await _basketService.Update(isThere);
                return Ok(isThere);
            }
            else
            {
                var res = await _basketService.Create(basket);
                return Ok(res);
            }
        }

        [HttpGet("GetAllBasketByUserId")]
        public async Task<IEnumerable<Basket>> GetAllBasketByUserId(Guid Id)
        {
            return await _basketService.GetAllBasketByUserId(Id);
        }

        [HttpGet("GetBasketById")]
        public async Task<Basket> GetBasketById(Guid Id)
        {
            return await _basketService.GetBasketById(Id);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Basket basket)
        {
            var deletedProduct = await _basketService.GetBasketById(basket.Id);

            if (deletedProduct.Piece > 1)
            {
                await _basketService.Drop(deletedProduct);
            }
            else
            {
                await _basketService.Delete(deletedProduct);
            }

            return Ok();
        }
    }
}
