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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISalesDetailService _salesDetailService;
        private readonly IBasketService _basketService;

        public ProductsController(IProductService productService, ISalesDetailService salesDetailService, IBasketService basketService)
        {
            _productService = productService;
            _salesDetailService = salesDetailService;
            _basketService = basketService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var res = await _productService.Create(product);
            return Ok(res);
        }

        [HttpPost("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(Product product)
        {
            await _productService.Delete(product.Id);

            return Ok();
        }

        [HttpPost("EditProduct")]
        public IActionResult EditProduct(Product product)
        {
            _productService.Update(product);

            return Ok();
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await _productService.GetAll();

            return Ok(res);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var res = await _productService.GetById(id);

            return Ok(res);
        }
    }
}
